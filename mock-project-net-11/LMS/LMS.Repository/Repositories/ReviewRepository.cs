using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Repository.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(LMSApplicationContext context, ILogger<ReviewRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage)
            : base(context, logger, responseMessage)
        {
        }

        #region Review a course of Instructor
        /// <summary>
        /// Get all courses review of Instructor 
        /// </summary>
        /// <param name="instructorId">Id of instructor</param>
        /// <returns>List review</returns>
        public async Task<List<Review>> GetAllReviewForInstructorAsync(int instructorId)
        {
            var review = await Context.Reviews
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.Course)
                .Where(r => r.IsDelete == false
                            &&
                            r.EnrollCourse.Course.InstructorId == instructorId)
                .ToListAsync();

            return review ?? new List<Review>();
        }
        /// <summary>
        /// Get detail all courses review of Instructor. 
        /// Detail: information of review ,information of course ,and information of user review
        /// </summary>
        /// <param name="instructorId">Id of instructor</param>
        /// <returns>List review</returns>
        public async Task<List<Review>> GetAllReviewDetailForInstructorAsync(int instructorId)
        {
            var review = await Context.Reviews
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.AppUser)
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.Course)
                .Where(r => r.IsDelete == false
                            &&
                            r.EnrollCourse.Course.InstructorId == instructorId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return review ?? new List<Review>();
        }
        /// <summary>
        /// Get review for courses of Instructor with paging
        /// Paging: pageNumber: position of page, pageSize: number record
        /// </summary>
        /// <param name="instructorId">Id of Instructor</param>
        /// <param name="pagingRequest">Paging: pageSize, pageCurrent</param>
        /// <returns>List review is paging</returns>
        public async Task<PaginatedList<Review>> GetReviewDetailForInstructorPaging(int instructorId, PagingRequest pagingRequest)
        {
            var query = Context.Reviews
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.AppUser)
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.Course)
                .Where(r => r.IsDelete == false
                            &&
                            r.EnrollCourse.Course.InstructorId == instructorId)
                .OrderByDescending(r => r.CreatedAt);

            return await PaginatedList<Review>.ToPaginatedListAsync(query,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
        }
        #endregion

        /// <summary>
        /// Get review by id
        /// </summary>
        /// <param name="id">Id of Review</param>
        /// <returns>Review</returns>
        public async Task<Review> GetReviewById(int? id)
        {
            if (id == null) return new Review();
            var review = await Context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review == null)
                return new Review();
            return review;
        }
        /// <summary>
        /// Search review from content
        /// </summary>
        /// <param name="key">value need search</param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        public async Task<PaginatedList<Review>> SearchReview(string key, PagingRequest pagingRequest)
        {

            var query = Context.Reviews
                .Include(r => r.EnrollCourse).ThenInclude(ec => ec.Course)
                .Include(r => r.EnrollCourse).ThenInclude(ec => ec.AppUser)
                .Where(r => r.IsDelete == false)
                .OrderByDescending(r => r.CreatedAt);
            //2. filter
            if (!string.IsNullOrEmpty(key))
                query = (IOrderedQueryable<Review>)query.Where(x => x.Content.Contains(key));

            return await PaginatedList<Review>.ToPaginatedListAsync(query,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
        }
        /// <summary>
        /// Get review by endCourseId
        /// </summary>
        /// <param name="endCourseId">Id of endCourse</param>
        /// <returns>List Review</returns>
        public async Task<Review> GetReviewByEnrollCourseId(int? enrollCourseId)
        {
            if (enrollCourseId == null) return null;
            var review = await Context.Reviews.FirstOrDefaultAsync(r => r.EnrollCourseId == enrollCourseId);
            if (review == null)
                return null;
            return review;
        }
        #region Review of course
        /// <summary>
        /// Get all course review
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <returns>List review</returns>
        public async Task<List<Review>> GetAllReviewForCourseAsync(int courseId)
        {
            var review = await Context.Reviews
                .Include(r => r.EnrollCourse).ThenInclude(ec => ec.Course)
                .Where(r => r.IsDelete == false
                            && r.EnrollCourse.CourseId == courseId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return review ?? new List<Review>();
        }
        /// <summary>
        /// Get detail course review
        /// Detail: information of review ,information of course ,and information of user review
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <returns>List review</returns>
        public async Task<List<Review>> GetAllReviewDetailForCourseAsync(int courseId)
        {
            var review = await Context.Reviews
                .Include(r => r.EnrollCourse).ThenInclude(ec => ec.AppUser)
                .Include(r => r.EnrollCourse).ThenInclude(ec => ec.Course)
                .Where(r => r.IsDelete == false && r.EnrollCourse.CourseId == courseId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return review ?? new List<Review>();
        }
        /// <summary>
        /// Get detail course review with paging
        /// Detail: information of review ,information of course ,and information of user review
        /// Paging: pageNumber: position of page, pageSize: number record
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <param name="pagingRequest">PageSize:number record, pageNumber: position of page</param>
        /// <returns>List review</returns>
        public async Task<PaginatedList<Review>> GetReviewDetailForCoursePaging(int courseId, PagingRequest pagingRequest)
        {
            var query = Context.Reviews
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.AppUser)
                .Include(r => r.EnrollCourse)
                .ThenInclude(ec => ec.Course)
                .Where(r => r.IsDelete == false
                            && r.EnrollCourse.CourseId == courseId)
                .OrderByDescending(r => r.CreatedAt);

            return await PaginatedList<Review>.ToPaginatedListAsync(query,
                    pagingRequest.PageNumber,
                    pagingRequest.PageSize);
        }
        /// <summary>
        /// Get list newest review for showing in course detail
        /// Paging: pageNumber: position of page, pageSize: number record
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List newest review of course</returns>
        public async Task<PaginatedList<Review>> GetAllReviewForCourseDetailAsync(int courseId, PagingRequest pagingRequest)
        {
            var query = Context.Reviews
                    .Include(r => r.EnrollCourse).ThenInclude(ec => ec.Course)
                    .Include(r => r.EnrollCourse).ThenInclude(ec => ec.AppUser)
                    .Where(r => r.IsDelete == false
                                && r.EnrollCourse.CourseId == courseId)
                    .OrderByDescending(r => r.CreatedAt);

            return await PaginatedList<Review>.ToPaginatedListAsync(query,
                pagingRequest.PageNumber,
                pagingRequest.PageSize);
        }
        public async Task<List<Review>> GetLatestReviews()
        {
            //Get current review (top 10)
            var reviewCurrent = await Context.Reviews
                .OrderByDescending(x => x.CreatedAt).Take(10)
                .Include(r => r.EnrollCourse).ThenInclude(ec => ec.AppUser)
                .ToListAsync();

            return reviewCurrent;
        }



        #endregion
    }
}
