using LMS.Repository.Entities;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<PaginatedList<Review>> GetReviewDetailForInstructorPaging(int instructorId, PagingRequest pagingRequest);
        Task<List<Review>> GetAllReviewForInstructorAsync(int instructorId);
        Task<List<Review>> GetAllReviewDetailForInstructorAsync(int instructorId);
        Task<List<Review>> GetAllReviewForCourseAsync(int courseId);
        Task<List<Review>> GetAllReviewDetailForCourseAsync(int courseId);
        Task<PaginatedList<Review>> GetReviewDetailForCoursePaging(int courseId, PagingRequest pagingRequest);
        Task<PaginatedList<Review>> SearchReview(string key, PagingRequest pagingRequest);
        Task<Review> GetReviewById(int? id);
        Task<PaginatedList<Review>> GetAllReviewForCourseDetailAsync(int courseId, PagingRequest pagingRequest);
        Task<Review> GetReviewByEnrollCourseId(int? enrollCourseId);

        /// <summary>
        /// get the latest 10 reviews
        /// </summary>
        /// <returns></returns>
        Task<List<Review>> GetLatestReviews();
    }
}
