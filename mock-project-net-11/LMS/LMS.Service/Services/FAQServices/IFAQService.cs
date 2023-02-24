using LMS.Model.Request.FAQDTOs;
using LMS.Model.Response.FAQs;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Service.Services.FAQServices
{
    public interface IFAQService
    {
        /// <summary>
        /// Service create FAQ
        /// </summary>
        /// <param name="FAQ">FAQ information create</param>
        /// <returns>true : create Success
        ///          false: create Fail</returns>
        Task<bool> CreateFAQAsync(FAQCreateDTO FAQ);
        /// <summary>
        /// Service update FAQ
        /// </summary>
        /// <param name="id">Id of FAQ</param>
        /// <param name="FAQ">FAQ information update</param>
        /// <returns>true : create Success
        ///          false: create Fail</returns>
        Task<bool> UpdateFAQAsync(int id, FAQEditDTO FAQ);
        /// <summary>
        /// Service get FAQ with paging
        /// </summary>
        /// <param name="request">pageNumber: position of page, pageSize: number record</param>
        /// <returns>List FAQDTO</returns>
        Task<PaginatedList<FAQDTO>> GetFAQAsyncPaging(PagingRequest request);
        /// <summary>
        /// Service get FAQ detail
        /// </summary>
        /// <param name="id">Id of FAQ</param>
        /// <returns>FAQ detail</returns>
        Task<FAQDetailDTO> GetDetailFAQById(int id);
    }
}
