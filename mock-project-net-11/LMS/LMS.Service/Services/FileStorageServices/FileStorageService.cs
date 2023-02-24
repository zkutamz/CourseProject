using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.RetryPolicies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;



namespace LMS.Service.Services.FileStorageServices
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "storage-upload";
        private readonly ILogger<FileStorageService> _logger;
        private readonly IConfiguration _configuration;
        private CloudStorageAccount cloudStorageAccount;
        public FileStorageService(IWebHostEnvironment webHostEnvironment, ILogger<FileStorageService> logger, IConfiguration configuration)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
            _logger = logger;
            _configuration = configuration;
            cloudStorageAccount = CloudStorageAccount.Parse(_configuration["StorageConnectionString"]);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task<bool> DeleteFileAsync(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_userContentFolder, fileName);
                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(DeleteFileAsync));
                throw;
            }

        }
        public async Task<string> SaveFile(IFormFile file)
        {
            try
            {
                var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
                var filePath = Path.Combine(_userContentFolder, fileName);
                if (!Directory.Exists(_userContentFolder))
                    Directory.CreateDirectory(_userContentFolder);
                using var output = new FileStream(filePath, FileMode.Create);
                await file.OpenReadStream().CopyToAsync(output);
                return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(SaveFile));
                throw;
            }
        }
        public async Task<List<string>> MultipleUpload(List<IFormFile> files)
        {
            try
            {
                var listUrl = new List<string>();
                foreach (var file in files)
                {
                    if (file != null)
                        listUrl.Add(await SaveFile(file));
                }

                return listUrl;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(MultipleUpload));
                throw;
            }

        }

        public async Task<string> UploadFileToAzure(IFormFile file)
        {
            try
            {
                var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                var cloudBlobContainer = cloudBlobClient.GetContainerReference(_configuration["ContainerName"]);

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Off });
                }

                var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName));
                cloudBlockBlob.Properties.ContentType = file.ContentType;

                await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream());

                return cloudBlockBlob.Uri.AbsoluteUri;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(SaveFile));
                throw;
            }
        }

        public async Task<byte[]> DownloadFileFromAzure(string fileUrl)
        {
            try
            {
                var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                var cloudBlobContainer = cloudBlobClient.GetContainerReference("lmsnet11container");

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Off });
                }
                var blob = new CloudBlockBlob(new Uri(fileUrl), cloudStorageAccount.Credentials);
                var blobRequestOptions = new BlobRequestOptions
                {
                    RetryPolicy = new NoRetry()
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    blob.DownloadToStream(ms, null, blobRequestOptions);
                    var array = ms.ToArray();
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DownloadFileFromAzure));
                throw;
            }

        }

        public async Task<bool> DeleteFileFromAzure(string url)
        {
            try
            {
                var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

                var cloudBlobContainer = cloudBlobClient.GetContainerReference("lmsnet11container");

                if (await cloudBlobContainer.CreateIfNotExistsAsync())
                {
                    await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Off });
                }
                var blob = new CloudBlockBlob(new Uri(url), cloudStorageAccount.Credentials);
                var deleteResult = await blob.DeleteIfExistsAsync();
                return deleteResult;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteFileFromAzure));
                throw;
            }
        }

        public async Task<List<string>> MultipleUploadToAzure(List<IFormFile> files)
        {
            try
            {
                var listUrl = new List<string>();
                foreach (var file in files)
                {
                    if (file != null)
                        listUrl.Add(await UploadFileToAzure(file));
                }

                return listUrl;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(MultipleUploadToAzure));
                throw;
            }
        }
    }
}
