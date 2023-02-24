using LMS.Model.Response.CourseDTOs;
using LMS.Repository.Paging;
using System.Threading.Tasks;
using CourseCommentDTO = LMS.Model.Response.CourseCommentDTOs.CourseCommentDTO;

namespace LMS.Service.Services.CourseManagementService
{
    public interface ICourseManagementService
    {
        Task<PagingResult<CourseCommentDTO>> GetTotalCommentOnCourse(int courseId, PagingRequest pagingRequest);
        Task<PagingResult<CourseDTO>> SearchCourse(string keyword, PagingRequest pagingRequest);

        Task<PaginatedList<CourseDTO>> GetAllPendingReview(PagingRequest pagingRequest);
        /// <summary>
        /// Get total QA comment on course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>PaginatedList<CourseCommentDTO></returns>
        Task<PaginatedList<CourseCommentDTO>> GetTotalQACommentOnCourse(int courseId, PagingRequest pagingRequest);

        /// <summary>
        /// Change course status to Active
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<bool> ActiveCourse(int courseId);
    }
}
