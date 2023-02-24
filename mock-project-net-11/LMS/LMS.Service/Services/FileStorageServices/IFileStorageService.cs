using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.FileStorageServices
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Get file Url
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string GetFileUrl(string fileName);
        //Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        /// <summary>
        /// Delete file with file name. (Ex: image.png)
        /// </summary>
        /// <param name="fileName">Ex: image.png</param>
        /// <returns>bool</returns>
        Task<bool> DeleteFileAsync(string fileName);
        /// <summary>
        /// Save file with file name (Ex: image.png)
        /// </summary>
        /// <param name="file"></param>
        /// <returns>string (url file)</returns>
        Task<string> SaveFile(IFormFile file);
        /// <summary>
        /// Upload file to microsoft Azure
        /// </summary>
        /// <param name="file"></param>
        /// <returns>file url</returns>
        Task<string> UploadFileToAzure(IFormFile file);
        /// <summary>
        /// Download file from azure
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <returns></returns>
        Task<byte[]> DownloadFileFromAzure(string fileUrl);

        /// <summary>
        /// Upload multiple file
        /// </summary>
        /// <param name="files">List IFormfile</param>
        /// <returns>List url</returns>
        Task<List<string>> MultipleUpload(List<IFormFile> files);
        Task<List<string>> MultipleUploadToAzure(List<IFormFile> files);
        /// <summary>
        /// Delete file from Azure
        /// </summary>
        /// <param name="url"></param>
        /// <returns>true if success</returns>
        Task<bool> DeleteFileFromAzure(string url);
    }
}
