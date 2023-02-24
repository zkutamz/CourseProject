using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface INoteRepository:IRepository<Notes>
    {
        Task<PaginatedList<Notes>> GetListNotesAsync(PagingRequest pagingRequest, int courseId, int lessonId, bool isFilterByAllLesson, bool isSortByOldest);
    }
}
