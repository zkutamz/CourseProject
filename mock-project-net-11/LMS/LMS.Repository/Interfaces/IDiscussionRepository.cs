using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IDiscussionRepository : IRepository<Discussion>
    {
        Task<PaginatedList<Discussion>> GetAllDiscussionAsync(int userId, PagingRequest pagingRequest);
        Task<Discussion> GetDiscussionWithReactionAsync(int discussionId);
    }
}
