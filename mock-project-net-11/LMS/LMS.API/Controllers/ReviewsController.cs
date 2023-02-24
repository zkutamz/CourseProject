using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.ReviewDTOs;
using LMS.Model.Response.ReviewDTOs;
using LMS.Model.Utilities;
using LMS.Repository.Paging;
using LMS.Service.Services.ReviewServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        /// <summary>
        /// API add review a course of User
        /// </summary>
        /// <param name="request">Review information create</param>
        /// <returns>Reponse</returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostReview(ReviewCreateDTO request)
        {
            return HandleResult(await _reviewService.CreateReviewAsync(request), LmsAction.Add);
        }
        /// <summary>
        /// API update Review acourse of User
        /// </summary>
        /// <param name="id">Id of Review</param>
        /// <param name="request">>Review information update</param>
        /// <returns>Reponse</returns>
        [Authorize]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> PutReview(int id, ReviewEditDTO request)
        {
            return HandleResult(await _reviewService.UpdateReviewAsync(id, request), LmsAction.Update);
        }
        /// <summary>
        /// Vote a review for it helpfulness.
        /// </summary>
        /// <param name="id">Id of an review</param>
        /// <param name="isHelpful">True if it's helpful, false if it's unhelpful</param>
        /// <returns>Success: return true as data | Failure: return false as data</returns>
        [Authorize]
        [HttpPut("/helpfulness/{id:int}")]
        public async Task<ActionResult<ResponseResult<bool>>> UpdateReviewHelpfulnessLevel(int id, [FromQuery] bool isHelpful)
        {
            return HandleResult(await _reviewService.UpdateTheHelpfulnessOfAnReviewAsync(id, isHelpful));
        }
        /// <summary>
        /// API find review by content
        /// </summary>
        /// <param name="search">Content want to find</param>
        /// <param name="pagingRequest"></param>
        /// <returns>List ReviewDTO</returns>
        [HttpGet]
        [Route("/api/review")]
        public async Task<IActionResult> SearchReview(string search, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _reviewService.SearchReviewAsync(search, pagingRequest), LmsAction.Add);
        }

        #region Instructor

        /// <summary>
        /// Api Calculate the number of ratings by level: 1, 2, 3, 4, 5 to review of course create by Instructor
        /// </summary>
        /// <param name="instructorId">Id of course</param>
        /// <returns>List int</returns>
        [HttpGet]
        [Route("instructor/{instructorId}/rating-level")]
        public async Task<IActionResult> GetRatingByInstructorId(int instructorId)
        {
            return HandleResult(await _reviewService.GetRatinCourseOfInstructorgAsync(instructorId));
        }
        /// <summary>
        /// Api Calculate average all rating to review of course create by Instructor
        /// </summary>
        /// <param name="instructorId">Id of course</param>
        /// <returns>float</returns>
        [HttpGet]
        [Route("instructor/{instructorId}/rating-average/")]
        public async Task<IActionResult> GetAverageRatingfOfInstructor(int instructorId)
        {
            return HandleResult(await _reviewService.GetAverageRatingCourseOfInstructorAsync(instructorId));
        }
        /// <summary>
        /// Api get list newest review to all course of specify Instructor
        /// </summary>
        /// <param name="instructorId">Id of Instructor</param>
        /// <param name="pagingRequest">PageSize:number record, pageNumber: position of page</param>
        /// <returns>List ReviewDTO</returns>
        [HttpGet]
        [Route("instructor/{instructorId}")]
        public async Task<IActionResult> GetAllReviewForInstructor(int instructorId, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _reviewService.GetAllReviewDetailDTOForInstruoctorAsync(instructorId, pagingRequest));
        }

        #endregion

        #region Course

        /// <summary>
        /// Api get a list of newest reviews of a specified course
        /// </summary>
        /// <param name="id">Id of course</param>
        /// <param name="pagingRequest">PageSize:number record, pageNumber: position of page</param>
        /// <returns>List ReviewDetailDTO object</returns>
        [HttpGet]
        [Route("course/{id:int}")]
        public async Task<ActionResult<ResponseResult<PagingResult<ReviewDetailDTO>>>> GetReviewOfCourse(int id, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _reviewService.GetAllReviewDetailDTOForCourseAsync(id, pagingRequest), LmsAction.Get);
        }
        /// <summary>
        /// Api Calculate the number of ratings by level: 1, 2, 3, 4, 5 to review of specify course
        /// </summary>
        /// <param name="courseId">Id of course</param>
        /// <returns>List int</returns>
        [HttpGet]
        [Route("couse/{courseId}/rating-level")]
        public async Task<IActionResult> GetRatingByCourseId(int courseId)
        {
            return HandleResult(await _reviewService.GetRatingCourseAsync(courseId));
        }
        /// <summary>
        /// Api Calculate average all rating to review of specify course
        /// </summary>
        /// <param name="courseId">Id of course</param>
        /// <returns>float</returns>
        [HttpGet]
        [Route("course/{courseId}/rating-average")]
        public async Task<IActionResult> GetAverageRatingByCourseId(int courseId)
        {
            return HandleResult(await _reviewService.GetAverageRatingCourseAsync(courseId));
        }

        [HttpGet("TheLatest5Reviews")]
        public async Task<IActionResult> LatestFiveReviews()
        {
            try
            {
                return HandleResult(await _reviewService.GetLatestReviews(), LmsAction.Get);

            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }
        }

        #endregion
    }
}
