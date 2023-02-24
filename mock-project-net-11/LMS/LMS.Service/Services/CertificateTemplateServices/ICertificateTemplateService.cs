using LMS.Model.Request.CertificateTemplateDTOs;
using LMS.Model.Response.TemplateDTOs;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.CertificateTemplateServices
{
    public interface ICertificateTemplateService
    {
        /// <summary>
        /// Get certificate template by id
        /// </summary>
        /// <param name="certificateTemplateId"></param>
        /// <returns> CertificateTemplateDTO </returns>
        Task<TemplateDTO> GetCertificateTemplateAsync(int certificateTemplateId);
        /// <summary>
        /// Return a list of CertificateTemplateDetailDTO and it paging 
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns> List Of CertificateTemplateDetailDTO</returns>
        Task<PagingResult<TemplateDetailDTO>> GetCertificateTemplatesAsync(PagingRequest pagingRequest);
        /// <summary>
        /// Create new CertificateTemplate 
        /// </summary>
        /// <param name="certificateTemplateDto"></param>
        /// <returns>True if Success, other wise throw errors message</returns>
        Task<bool> CreateCertificateTemplateAsync(CertificateTemplateCreateDTO certificateTemplateDto);
        /// <summary>
        /// Soft delete a CertificateTemplate base on Id, it will update the status in the database
        /// </summary>
        /// <param name="certificateTemplateId"></param>
        /// <returns>True if Success, other wise throw errors message</returns>
        Task<bool> SoftDeleteCertificateTemplateAsync(int certificateTemplateId);
        /// <summary>
        /// Update a existed CertificateTemplate 
        /// </summary>
        /// <param name="certificateTemplateId"></param>
        /// <param name="certificateTemplateEditDTO"></param>
        /// <returns>True if Success, other wise throw errors message</returns>

        Task<bool> UpdateCertificateTemplateAsync(int certificateTemplateId, CertificateTemplateEditDTO certificateTemplateEditDTO);

    }
}
