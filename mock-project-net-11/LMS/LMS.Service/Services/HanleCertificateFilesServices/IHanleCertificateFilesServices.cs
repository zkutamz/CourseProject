using LMS.Repository.Entities;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LMS.Service.Services.HanleCertificateServices
{
    public interface IHanleCertificateFilesServices
    {
        /// <summary>
        /// Generate certificate image
        /// </summary>
        /// <param name="user"></param>
        /// <param name="certificate"></param>
        /// <returns></returns>
        Task<string> HandleCertificateImageAsync(AppUser user, Certificate certificate);
        /// <summary>
        /// Save file to wwwroot base on folders input
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folderNames"></param>
        /// <returns></returns>
        Task<string> SaveFileAsync(IFormFile file, params string[] folderNames);
        /// <summary>
        /// Delete file base one file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>True if success ortherwise return false</returns>
        Task DeleteFileAsync(string filePath);
        /// <summary>
        /// Get folders and  concat it 
        /// </summary>
        /// <param name="folderNames"></param>
        /// <returns>File path</returns>
        string GetFilePath(params string[] folderNames);
    }
}
