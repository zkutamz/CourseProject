using LMS.Model.Request.TemplateDTOs;
using LMS.Model.Response.TemplateDTOs;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.TemplateServices
{
    public interface ITemplateService
    {
        /// <summary>
        /// Get template by it id
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns><see cref="TemplateDTO"/></returns>
        Task<TemplateDTO> GetTemplateAsync(int templateId);
        /// <summary>
        /// Template a list of temlates
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns>List of <see cref="TemplateDTO"/></returns>
        Task<PagingResult<TemplateDTO>> GetTemplatesAsync(PagingRequest pagingRequest);
        /// <summary>
        /// Create new template
        /// </summary>
        /// <param name="templateCreateDTO"></param>
        /// <returns>True if success, otherwise throw error message</returns>
        Task<bool> CreateTemplateAsync(TemplateCreateDTO templateCreateDTO);
        /// <summary>
        /// Soft delete template base on it id
        /// </summary>
        /// <param name="templateId"></param>
        /// <returns>True if success, otherwise throw error message</returns>
        Task<bool> SoftDeleteTemplateAsync(int templateId);
        /// <summary>
        /// Update existed template
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="templateEditDTO"></param>
        /// <returns>True if success, otherwise throw error message</returns>
        /// <returns></returns>
        Task<bool> UpdateTemplateAsync(int templateId, TemplateEditDTO templateEditDTO);
    }
}
