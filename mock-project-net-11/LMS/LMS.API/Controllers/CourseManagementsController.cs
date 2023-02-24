using LMS.Model.Constant;
using LMS.Model.Request.CourseDiscountDTOs;
using LMS.Model.Request.CoursePromotionDTOs;
using LMS.Repository.Paging;
using LMS.Service.Extensions;
using LMS.Service.Services.CourseManagementService;
using LMS.Service.Services.CourseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CourseManagementController : BaseController
    {
        private readonly ICourseManagementService _courseManagementService;
        private readonly ICourseService _courseService;
        private readonly Task<int> _userId;

        public CourseManagementController(
            ICourseManagementService courseManagementService,
            ICourseService courseService,
            IUserAccessor userAccessor)
        {
            _courseManagementService = courseManagementService;
            _courseService = courseService;
            _userId = userAccessor.GetUserId();
        }
        /// <summary>
        /// Get total comment on Course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTotalCommentOnCourse")]
        public async Task<IActionResult> GetTotalCommentOnCourse(int courseId, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _courseManagementService.GetTotalCommentOnCourse(courseId, pagingRequest), LmsAction.Get);
        }
        [HttpGet]
        [Route("SearchCourse")]
        public async Task<IActionResult> SearchCourse(string keyword, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _courseManagementService.SearchCourse(keyword, pagingRequest), LmsAction.Get);
        }

        [HttpGet]
        [Route("GetAllActiveCourseOfInstructor")]
        public async Task<IActionResult> GetAllActiveCourseOfInstructor([FromQuery] PagingRequest pageQueryParams)
        {
            return HandleResult(await _courseService.GetAllActiveCourseOfInstructor(await _userId, pageQueryParams), LmsAction.Get);
        }
        [HttpGet]
        [Route("GetAllPurchaseCourseOfInstructor")]
        public async Task<IActionResult> GetAllPurchaseCourseOfInstructor([FromQuery] PagingRequest pageQueryParams)
        {
            return HandleResult(await _courseService.GetAllPurchasedCoursesOfStudent(await _userId, pageQueryParams), LmsAction.Get);
        }

        [HttpGet]
        [Route("GetAllPendingCourseOfInstructor")]
        public async Task<IActionResult> GetAllPendingCourseOfInstructor([FromQuery] PagingRequest pageQueryParams)
        {
            return HandleResult(await _courseService.GetAllPendingCourseOfInstructor(await _userId, pageQueryParams), LmsAction.Get);
        }
        [HttpGet]
        [Route("GetAllDiscountCourseOfInstructor")]
        public async Task<IActionResult> GetAllDiscountCourseOfInstructor([FromQuery] PagingRequest pageQueryParams)
        {
            return HandleResult(await _courseService.GetAllDiscountCourseOfInstructor(await _userId, pageQueryParams), LmsAction.Get);
        }
        [HttpGet]
        [Route("GetCourseByIdAsync")]
        public async Task<IActionResult> GetCourseByIdAsync(int courseid)
        {
            return HandleResult(await _courseService.GetCourseByIdAsync(courseid), LmsAction.Get);
        }
        /// <summary>
        /// delete active course - update isDeleted is true
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("DisableActiveCourseByIdAsync")]
        public async Task<IActionResult> DisableActiveCourseByIdAsync(int courseid)
        {
            return HandleResult(await _courseService.DisableActiveCourseByIdAsync(await _userId, courseid), LmsAction.Update);
        }
        /// <summary>
        /// Delete pending Course
        /// </summary>
        /// <param name="courseid"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeletePendingCourseById")]
        public async Task<IActionResult> DeletePendingCourseByIdAsync(int courseid)
        {
            return HandleResult(await _courseService.DeletePendingCourse(await _userId, courseid), LmsAction.Delete);
        }
        /// <summary>
        /// create discount for a course
        /// </summary>
        /// <param name="courseDiscountCreateDTO">discount information</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCourseDiscount")]
        public async Task<IActionResult> CreateCourseDiscountAsync([FromForm] CourseDiscountCreateDTO courseDiscountCreateDTO)
        {
            return HandleResult(await _courseService.CreateCourseDiscountAsync(await _userId, courseDiscountCreateDTO), LmsAction.Add);
        }
        /// <summary>
        /// update discount for a course
        /// </summary>
        /// <param name="courseDiscountId">id of discount in sales off date</param>
        /// <param name="courseDiscountCreateDTO">discount information</param>
        /// <returns></returns>

        [HttpPut]
        [Route("UpdateCourseDiscount")]
        public async Task<IActionResult> UpdateCourseDiscountAsync(int courseDiscountId, CourseDiscountEditDTO courseDiscountCreateDTO)
        {
            return HandleResult(await _courseService.UpdateCourseDiscountAsync(await _userId, courseDiscountId, courseDiscountCreateDTO), LmsAction.Update);
        }
        /// <summary>
        /// delete logic a course discount
        /// </summary>
        /// <param name="courseDiscountId">courseDiscount's id</param>
        /// <returns></returns>

        [HttpPut]
        [Route("DisposeCourseDiscount")]
        public async Task<IActionResult> DisposeCourseDiscountAsync(int courseDiscountId)
        {
            return HandleResult(await _courseService.DisposeCourseDiscountAsync(await _userId, courseDiscountId), LmsAction.Delete);
        }

        /// <summary>
        /// create new promotion
        /// </summary>
        /// <param name="coursePromotionCreateDTO">promotion's information</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("CreatePromotion")]
        public async Task<IActionResult> CreatePromotion([FromForm] CoursePromotionCreateDTO coursePromotionCreateDTO)
        {
            return HandleResult(await _courseService.CreatePromotionAsync(await _userId, coursePromotionCreateDTO), LmsAction.Add);
        }

        [HttpPut]
        [Route("UpdatePromotion")]
        public async Task<IActionResult> UpdatePromotion(int promotionId, [FromForm] CoursePromotionCreateDTO coursePromotionCreateDTO)
        {
            return HandleResult(await _courseService.UpdateCoursePromotion(await _userId, promotionId, coursePromotionCreateDTO), LmsAction.Update);
        }

        [HttpPut]
        [Route("DisposePromotion")]
        public async Task<IActionResult> DeletePromotion(int promotionId)
        {
            return HandleResult(await _courseService.DeletePromotionAsync(await _userId, promotionId), LmsAction.Delete);
        }
        [HttpGet]
        [Route("GetTheAllCoursesBeingReviewedByTheAdmin")]
        public async Task<IActionResult> GetAllCourseBeingReview([FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _courseManagementService.GetAllPendingReview(pagingRequest));
        }
        /// <summary>
        /// Get total QA comment on course
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        [HttpGet("{courseId}/get-total-qa-comment-on-course")]
        public async Task<IActionResult> GetAllQACommentOnCourse(int courseId,
            [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _courseManagementService.GetTotalQACommentOnCourse(courseId, pagingRequest));
        }

        /// <summary>
        /// Change course status to Active
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("active/{courseId}")]
        [Authorize(Roles = Roles.ADMIN)]
        public async Task<IActionResult> ActiveCourse(int courseId)
        {
            return HandleResult(await _courseManagementService.ActiveCourse(courseId));
        }
    }
}
