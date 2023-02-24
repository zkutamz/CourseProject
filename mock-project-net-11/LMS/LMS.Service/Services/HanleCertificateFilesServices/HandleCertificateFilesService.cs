using LMS.Model.Exceptions;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.HanleCertificateServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LMS.Service.Services.HanleCertificateFilesServices
{
    public class HandleCertificateFilesService : IHanleCertificateFilesServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HandleCertificateFilesService> _logger;

        public HandleCertificateFilesService(
            IWebHostEnvironment webHostEnvironment,
            IUnitOfWork unitOfWork,
            ILogger<HandleCertificateFilesService> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<string> HandleCertificateImageAsync(AppUser user, Certificate certificate)
        {
            string guid = Guid.NewGuid().ToString();
            //To save temporary cetificate template file
            var tempFolder = _webHostEnvironment.WebRootPath + GetFilePath("Certificates", "Templates", "temp");
            var CertificateImageFolder = _webHostEnvironment.WebRootPath+ GetFilePath("Certificates", "CertificateImages");
            if (!Directory.Exists(tempFolder))
            {
                Directory.CreateDirectory(tempFolder);
            }
            if (!Directory.Exists(CertificateImageFolder))
            {
                Directory.CreateDirectory(CertificateImageFolder);
            }
            string tempHtmlTemplatePath = GetFilePath("Certificates", "Templates", "temp") + Path.DirectorySeparatorChar + guid + ".html";
            //Paht to save certificate image
            string certificateImagePath = GetFilePath("Certificates", "CertificateImages") + Path.DirectorySeparatorChar + guid + $"_{user.FirstName}" + $"{user.LastName}" + ".png";
            try
            {
                var templatePath = _webHostEnvironment.WebRootPath + await GetTemplateFilePath(certificate);
                await ChangeContentHTMLFileAsync(templatePath, tempHtmlTemplatePath, user, certificate);
                ConvertHTMLToImage(tempHtmlTemplatePath, certificateImagePath);
                return certificateImagePath;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                _logger.LogError(exception.Message);
                throw;
            }
            finally
            {
                await DeleteFileAsync(tempHtmlTemplatePath);
            }
        }
        /// <summary>
        /// Change the content of html template file
        /// </summary>
        /// <param name="htmlFilePath"></param>
        /// <param name="tempHTMLFile"></param>
        /// <param name="user"></param>
        /// <param name="certificate"></param>
        private async Task ChangeContentHTMLFileAsync(
            string htmlFilePath,
            string tempHTMLFile,
            AppUser user,
            Certificate certificate)
        {
            var bodyHtml = string.Empty;
            using (StreamReader reader = File.OpenText(htmlFilePath))
            {
                bodyHtml = reader.ReadToEnd();
            }
            if (certificate.IsForCourse)
            {
                var courseName = await GetCourseNameByIdAsync((int)certificate.CourseId);
                bodyHtml = bodyHtml.Replace("{UserName}", user.LastName + " " + user.FirstName);
                bodyHtml = bodyHtml.Replace("{CourseName}", courseName);
            }
            else
            {
                bodyHtml = bodyHtml.Replace("{UserName}", user.FirstName + " " + user.LastName);
                bodyHtml = bodyHtml.Replace("{CertificateName}", certificate.CertificateName);
            }

            File.WriteAllText(_webHostEnvironment.WebRootPath + tempHTMLFile, bodyHtml);

        }
        /// <summary>
        /// Convert HTML file to an image
        /// </summary>
        /// <param name="htmlFilePath"></param>
        private void ConvertHTMLToImage(string htmlFilePath, string imagePath)
        {
            using (var document = new Aspose.Html.HTMLDocument(_webHostEnvironment.WebRootPath + htmlFilePath))
            {
                // Initialize ImageSaveOptions 
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                // Convert HTML to PNG
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, _webHostEnvironment.WebRootPath + imagePath);
            }
        }

        public async Task<string> SaveFileAsync(IFormFile file, params string[] folderNames)
        {
            try
            {
                var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
                string filePath = _webHostEnvironment.WebRootPath + GetFilePath(folderNames) + Path.DirectorySeparatorChar + fileName;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return GetFilePath(folderNames) + Path.DirectorySeparatorChar + fileName;
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                _logger.LogError(exeption.Message);
                throw;
            }
        }
        public async Task DeleteFileAsync(string filePath)
        {
            var fullPath = _webHostEnvironment.WebRootPath + filePath;
            try
            {
                if (!File.Exists(fullPath))
                {
                    throw new NotFoundException();
                }
                await Task.Run(() => File.Delete(fullPath));
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                _logger.LogError(exception.Message);
                throw;
            }

        }
        public string GetFilePath(params string[] folderNames)
        {
            var filePath = string.Empty;
            foreach (var item in folderNames)
            {
                filePath = filePath + Path.DirectorySeparatorChar.ToString() + item;
            }
            return filePath;
        }
        /// <summary>
        /// Get template URL
        /// </summary>
        /// <param name="certificate"></param>
        /// <returns>string</returns>
        private async Task<string> GetTemplateFilePath(Certificate certificate)
        {
            var templates = await _unitOfWork.TemplateRepository.GetTemplateBaseOnStatus(certificate.IsForCourse);
            return templates.TemplateUrl;
        }
        private async Task<string> GetCourseNameByIdAsync(int courseId)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(x => x.Id == courseId && x.IsDelete == false);
            if (course == null) throw new NotFoundException();
            return course.Title;
        }
    }
}
