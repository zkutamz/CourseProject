using LMS.Service.Services.FileStorageServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Utilities
{
    public static class FileHelper
    {
        private readonly static IFileStorageService _fileStorageService;
        private const string USER_CONTENT_FOLDER_NAME = "storage-upload";
        private readonly static ILogger<FileStorageService> _logger = new LoggerFactory().CreateLogger<FileStorageService>();
        private readonly static IConfiguration _configuration;
        static FileHelper()
        {
            var _accessor = new HttpContextAccessor();
            _fileStorageService = new FileStorageService(
                _accessor.HttpContext.RequestServices.GetRequiredService<IWebHostEnvironment>(), _logger, _configuration);
        }
        /// <summary>
        /// Save file 
        /// </summary>
        /// <param name="file"></param>
        /// <returns>string (url)</returns>
        public async static Task<string> SaveFile(IFormFile file)
        {
            try
            {
                return await _fileStorageService.SaveFile(file); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Save multiple file
        /// </summary>
        /// <param name="file"></param>
        /// <returns>List<string> (list url)</string></returns>
        public async static Task<List<string>> SaveMultipleFile(List<IFormFile> file)
        {
            try
            {
                return await _fileStorageService.MultipleUpload(file); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="fileName">Ex: image.png</param>
        /// <returns>bool</returns>
        public async static Task<bool> DeleteFile(string fileName)
        {
            try
            {
                return await _fileStorageService.DeleteFileAsync(fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
