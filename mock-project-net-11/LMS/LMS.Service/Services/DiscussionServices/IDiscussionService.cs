using System.Collections.Generic;
using LMS.Model.Request.DiscussionDTOs;
using LMS.Model.Response.DiscussionDTOs;
using System.Threading.Tasks;
using LMS.Model.Request.ReactDTOs;
using LMS.Repository.Paging;

namespace LMS.Service.Services.DiscussionServices
{
    public interface IDiscussionService
    {
        Task<bool> AddAsync(int userId, DiscussionCreateDTO request);
        Task<bool> UpdateAsync(int id, DiscussionEditDTO request);
        Task<bool> DeleteAsync(int id);
        Task<DiscussionDTO> GetAsync(int id);
        Task<List<DiscussionDTO>> GetAllAsync(int userId, PagingRequest pagingRequest);
        Task<bool> ReactAsync(int currentUserId ,ReactCreateDTO request);

    }
}
