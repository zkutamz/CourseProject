using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface ICourseCommentRepository : IRepository<CourseComment>
    {
        Task<PaginatedList<CourseComment>> GetTotalCommentOnCourse(int courseId, PagingRequest pagingRequest);
        /// <summary>
        /// Get total QA comment on course 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>PaginatedList<CourseComment></returns>
        Task<PaginatedList<CourseComment>> GetTotalQACommentOnCourse(int courseId, PagingRequest pagingRequest);
    }
}
