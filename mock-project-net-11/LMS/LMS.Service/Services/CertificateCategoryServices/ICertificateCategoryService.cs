using LMS.Model.Request.CertificateCategoryDTOs;
using LMS.Model.Response.CertificateCategoryDTOs;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.CertificateCategoryServices
{
    public interface ICertificateCategoryService
    {
        /// <summary>
        /// Get certificate category base on id 
        /// </summary>
        /// <param name="certificateCategoryId"></param>
        /// <returns><see cref="CertificateCategoryDTO"/></returns>
        Task<CertificateCategoryDTO> GetCertificateCategoryById(int certificateCategoryId);
        /// <summary>
        /// Get all certificate category
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>List of <see cref="CertificateCategoryDTO"/></returns>
        Task<PagingResult<CertificateCategoryDTO>> GetCertificateCategories(PagingRequest pagingRequest);
        /// <summary>
        /// Create new certificate category
        /// </summary>
        /// <param name="certificateCategoryCreateDto"></param>
        /// <returns>True if success otherwise throw error message</returns>
        Task<bool> CreateCertificateCategoryAsync(CertificateCategoryCreateDTO certificateCategoryCreateDto);
        /// <summary>
        /// Update existed certificate category
        /// </summary>
        /// <param name="certificateCategoryEditDto"></param>
        /// <returns>True if success, otherwise throw error message</returns>
        Task<bool> UpdateCertificateCategoryAsync(CertificateCategoryEditDTO certificateCategoryEditDto);
        /// <summary>
        /// Delete existed certificate category
        /// </summary>
        /// <param name="ceritificateCategoryId"></param>
        /// <returns>True if success,otherwise throw error message</returns>
        Task<bool> SoftDeleteCertificateCategoryAsync(int ceritificateCategoryId);
    }
}
