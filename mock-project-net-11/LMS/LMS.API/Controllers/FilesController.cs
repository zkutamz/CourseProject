using LMS.Model.Constant;
using LMS.Service.Services.FileStorageServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private const string DIRECTORY = "wwwroot/storage-upload";
        private readonly IFileStorageService _fileStorageService;
        public FilesController(IWebHostEnvironment webHostEnvironment, IFileStorageService fileStorageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _fileStorageService = fileStorageService;
        }
        /// <summary>
        /// Upload file with iform file to local
        /// </summary>
        /// <param name="file"></param>
        /// <returns>url file</returns>
        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            return HandleResult(await _fileStorageService.SaveFile(file), LmsAction.Add);
        }
        /// <summary>
        /// Multiple upload file to local
        /// </summary>
        /// <param name="files">List Iform file</param>
        /// <returns>List Url</returns>
        [HttpPost("upload-files")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            return HandleResult(await _fileStorageService.MultipleUpload(files), LmsAction.Add);
        }
        /// <summary>
        /// Upload file to Azure
        /// </summary>
        /// <param name="file"></param>
        /// <returns>file url</returns>
        [HttpPost("upload-file-to-azure")]
        public async Task<IActionResult> UploadFileToAzure(IFormFile file)
        {
            return HandleResult(await _fileStorageService.UploadFileToAzure(file), LmsAction.Add);
        }
        /// <summary>
        /// Multiple upload file to Azure
        /// </summary>
        /// <param name="files"></param>
        /// <returns>List file Url</returns>
        [HttpPost("multiple-upload-file-to-azure")]
        public async Task<IActionResult> MultipleUploadFileToAzure(List<IFormFile> files)
        {
            return HandleResult(await _fileStorageService.MultipleUploadToAzure(files), LmsAction.Add);
        }
        /// <summary>
        /// Delete file with file name from local
        /// </summary>
        /// <param name="fileName">Ex: image.png</param>
        /// <returns>bool</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            return HandleResult(await _fileStorageService.DeleteFileAsync(fileName), LmsAction.Delete);
        }

        #region Download File  
        /// <summary>
        /// Download file with name ex: image.png from local
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpGet(nameof(Download))]
        public IActionResult Download([Required] string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            var file = Path.Combine(_webHostEnvironment.ContentRootPath, DIRECTORY, path);
            string contentType;
            if (!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }

            byte[] fileBytes;
            if (System.IO.File.Exists(file))
            {
                fileBytes = System.IO.File.ReadAllBytes(file);
            }
            else
            {
                return NotFound();
            }
            return File(fileBytes, contentType, path);
        }
        /// <summary>
        /// Download file from Azure
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        [HttpGet("download-file-from-azure")]
        public async Task<IActionResult> DownloadFileFromAzure([Required] string fileUrl)
        {

            var provider = new FileExtensionContentTypeProvider();
            var file = Path.Combine(_webHostEnvironment.ContentRootPath, DIRECTORY);
            var fileName = fileUrl.Split("/").Last();
            string contentType;
            if (!provider.TryGetContentType(file, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return File(await _fileStorageService.DownloadFileFromAzure(fileUrl), contentType, fileName);
        }
        [HttpDelete("delete-file-from-azure")]
        public async Task<IActionResult> DeleteFileFromAzure([Required] string fileUrl)
        {
            return HandleResult(await _fileStorageService.DeleteFileFromAzure(fileUrl), LmsAction.Delete);
        }
        #endregion

    }
}
