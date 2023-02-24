using LMS.Model.Request.ReviewDTOs;
using LMS.Model.Response.ReviewDTOs;
using LMS.Repository.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.ReviewServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IReviewService
    {

        #region Review,Rating courses of Instructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idInstructor"></param>
        /// <returns></returns>
        Task<double> GetAverageRatingCourseOfInstructorAsync(int idInstructor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idInstructor"></param>
        /// <returns></returns>
        Task<List<int>> GetRatinCourseOfInstructorgAsync(int idInstructor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<ReviewDetailDTO>> GetAllReviewDetailDTOForInstruoctorAsync(int instructorId, PagingRequest request);
        #endregion

        #region Review, Rating course

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<double> GetAverageRatingCourseAsync(int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        Task<List<int>> GetRatingCourseAsync(int courseId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagingResult<ReviewDetailDTO>> GetAllReviewDetailDTOForCourseAsync(int courseId, PagingRequest request);
        #endregion

        /// <summary>
        /// Create Review course from user
        /// </summary>
        /// <param name="request">Content of Review
        ///                     Rating of Review for course
        ///                     UserId id of user review</param>
        ///                     CourseId id of course is review
        ///                     EnrollCourseId id of Enroll Course
        /// <returns>ReviewDTO object</returns>
        Task<ReviewDTO> CreateReviewAsync(ReviewCreateDTO request);

        /// <summary>
        /// Update an existing review.
        /// </summary>
        /// <param name="request">Review request to update</param>
        /// <returns>true: update success
        ///         false: update failed</returns>
        /// 
        Task<bool> UpdateReviewAsync(int id, ReviewEditDTO request);
        /// <summary>
        /// Delete Review course from user
        /// </summary>
        /// <param name="id">id of review</param>
        /// <returns>true: delete success
        ///         false: delete failed</returns>
        /// 
        Task<bool> DeleteReviewAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagingResult<ReviewDetailDTO>> SearchReviewAsync(string key, PagingRequest request);

        /// <summary>
        /// This method gets a featured review, review that's the highest rating and highest helpfulness, of a course.
        /// </summary>
        /// <param name="courseId">CourseId to filter</param>
        /// <returns>A ReviewFeaturedDTO object</returns>
        Task<ReviewFeaturedDTO> GetAFeaturedReviewAsync(int courseId);

        /// <summary>
        /// This method makes changes to the helpfulness level of an review.
        /// </summary>
        /// <param name="reviewId">ID of an review to filter</param>
        /// <param name="isHelpful">True: Helpful | False: Not Helpful</param>
        /// <returns>Success: return true | Failure: return false</returns>
        Task<bool> UpdateTheHelpfulnessOfAnReviewAsync(int reviewId, bool isHelpful);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<ReviewDetailDTO>> GetLatestReviews();
    }
}
