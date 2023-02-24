using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.CourseDTOs;
using LMS.Model.Request.SearchDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.CourseFavoriteDTOs;
using LMS.Model.Response.SectionDTOs;
using LMS.Model.Utilities;
using LMS.Repository.Paging;
using LMS.Service.Services.CourseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]

    public class CoursesController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CoursesController> _logger;
        private readonly ResponseMessageOptions _responseMessage;

        public CoursesController(
            ICourseService courseService, 
            ILogger<CoursesController> logger,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage)
        {
            _courseService = courseService;
            _logger = logger;
            _responseMessage = responseMessage.Value;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetAllCourseAsync(pagingRequest), LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }
        }

        /// <summary>
        /// Get Total Student Enroll To Instructor
        /// </summary>
        /// <param name="intstructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("StudentEnrollToInstructor")]
        public async Task<IActionResult> StudentEnrollToInstructor(int intstructorId, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetTotalStudentEnrollToInstructor(intstructorId, pagingRequest), LmsAction.Get);
            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }

        }

        /// <summary>
        /// Get Total Student Studied To Instructor
        /// </summary>
        /// <param name="intstructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("StudentStudiedToInstructor")]
        public async Task<IActionResult> StudentStudiedToInstructor(int intstructorId, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetTotalStudentStudiedToInstructor(intstructorId, pagingRequest), LmsAction.Get);

            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }
        }
        /// <summary>
        /// Get Total Number To Instructor Courses
        /// </summary>
        /// <param name="intstructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("NumberToInstructorCourses")]
        public async Task<IActionResult> NumberToInstructorCourses(int intstructorId, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetTotalNumberToInstructorCourses(intstructorId, pagingRequest), LmsAction.Get);

            }
            catch (Exception e)
            {
                throw new BadRequestException($"Something went wrong!. {e}");
            }
        }

        /// <summary>
        /// Get Latest Course Performance Information
        /// </summary>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("LatestCoursePerformanceInformation")]
        public async Task<IActionResult> LatestCoursePerformanceInformation([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetLatestCoursePerformanceInformation(pagingRequest), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        #region Favorite Course

        /// <summary>
        /// Get all Favorite Courses of a user.
        /// </summary>
        /// <remarks>User's ID will be extract from authentication token</remarks>
        /// <param name="pagingRequest">PagingRequest</param>
        /// <returns>PagingResult CourseFavoriteDTO object</returns>
        [Authorize]
        [HttpGet("favorites")]
        public async Task<ActionResult<ResponseResult<PagingResult<CourseFavoriteDTO>>>> GetAllFavoriteCourses([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                var result = await _courseService.GetAllFavoriteCoursesAsync(pagingRequest);

                if (result is null) return NotFound(_responseMessage.NotFound);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetAllFavoriteCourses));
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Save course to  list favorite course of user.
        /// </summary>
        /// <remarks>User's ID will be extract from authentication token</remarks>
        /// <param name="courseId">ID of a course</param>
        /// <returns>true:success, false: failed</returns>
        [Authorize]
        [HttpPost("{courseId:int}/favorites")]
        public async Task<ActionResult<ResponseResult<bool>>> CreateFavoriteCourse(int courseId)
        {
            try
            {
                var result = await _courseService.CreateFavoriteCourseAsync(courseId);

                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }

                return HandleResult(true, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateFavoriteCourse));
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Delete favorite course of user by course id
        /// </summary>
        /// <remarks>User's ID will be extract from authentication token</remarks>
        /// <param name="courseId">Course ID to filter</param>
        /// <returns>true:success, false: failed</returns>
        [Authorize]
        [HttpDelete("{courseId:int}/favorites")]
        public async Task<IActionResult> DeleteFavoriteCourse(int courseId)
        {
            try
            {
                var result = await _courseService.DeleteFavoriteCourseAsync(courseId);

                if (result is false)
                    return BadRequest(_responseMessage.DeleteFailure);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(DeleteFavoriteCourse));
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Delete all favorite course of user by userID
        /// </summary>
        /// <remarks>User's ID will be extract from authentication token</remarks>
        /// <returns>true:success, false: failed</returns>
        [Authorize]
        [HttpDelete("favorites")]
        public async Task<IActionResult> DeleteAllFavoriteCourse()
        {
            try
            {
                var result = await _courseService.DeleteAllFavoriteCourseAsync();

                if (!result) return BadRequest(_responseMessage.DeleteFailure);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(DeleteAllFavoriteCourse));
                throw new BadRequestException(_responseMessage.ErrorOccurred);
            }
        }
        #endregion
        /// <summary>
        /// get all Purchased Courses of this student
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("PurchasedStudent")]
        public async Task<IActionResult> PurchasedStudent(int studentId, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetAllPurchasedCoursesOfStudent(studentId, pagingRequest), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }


        }
        /// <summary>
        /// Get All Purchased Of System
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("PurchasedOfSystem")]
        public async Task<IActionResult> PurchasedOfSystem([FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetAllPurchasedCoursesOfSystem(pagingRequest), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }


        }

        /// <summary>
        /// Get All Total New Purchased In One Month
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("TotalNewPurchasedInOneMonth")]
        public async Task<IActionResult> TotalNewPurchasedInOneMonth()
        {
            try
            {
                return HandleResult(await _courseService.GetNewPurchasedCoursesIn1Month(), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }


        }
        /// <summary>
        /// Get Teacher By Name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>info teacher</returns>
        [HttpGet("GetTeacherByName")]
        public async Task<IActionResult> GetTeacherByName(string userName)
        {
            try
            {
                return HandleResult(await _courseService.GetTeacherByName(userName), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// get info purchased course(download)
        /// </summary>
        /// <param name="enrollId"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("PrintPurchasedCourses")]
        public async Task<IActionResult> PrintPurchasedCourses(int enrollId)
        {
            try
            {
                return HandleResult(await _courseService.PrintPurchasedCourses(enrollId), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        /// <summary>
        /// GetAllCourseByCategoryName
        /// </summary>
        /// <param name="categoryName"> </param>
        /// <param name="pagingRequest"></param>
        /// <returns>return list course by category</returns>
        [HttpGet("CourseByCategoryName")]
        public async Task<IActionResult> GetAllCourseByCategoryName(string categoryName, [FromQuery] PagingRequest pagingRequest)
        {
            try
            {
                return HandleResult(await _courseService.GetAllCourseByCategoryName(categoryName, pagingRequest), LmsAction.Add);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }
        /// <summary>
        /// Get current course being study
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCurrentCourse")]
        public async Task<IActionResult> GetCurrentCourse()
        {
            try
            {
                return HandleResult(await _courseService.GetCurrentCourse(), LmsAction.Get);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Get a course information for course detail page
        /// </summary>
        /// <param name="courseId">Course ID to filter</param>
        /// <returns>A Course DTO object</returns>
        [HttpGet("{courseId:int}")]
        public async Task<ActionResult<CourseDetailDTO>> GetCourse(int courseId)
        {
            return HandleResult(await _courseService.GetCourse(courseId));
        }

        /// <summary>
        /// Get sections of a course
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>A list of Section basic DTO objects</returns>
        [HttpGet("{courseId:int}/sections")]
        public async Task<ActionResult<List<SectionBasicDTO>>> GetCourseSections(int courseId)
        {
            return HandleResult(await _courseService.GetCourseSections(courseId));
        }

        /// <summary>
        /// Get a section of a course with completion checker
        /// </summary>
        /// <param name="courseId">Course ID to filter</param>
        /// <param name="sectionId">Section ID to filter</param>
        /// <returns>A Section basic DTO object</returns>
        [HttpGet("{courseId:int}/section-study/{sectionId:int}")]
        public async Task<ActionResult<SectionBasicDTO>> GetCourseSectionForStudy(int courseId, int sectionId)
        {
            return HandleResult(await _courseService.GetCourseSectionForStudy(courseId, sectionId));
        }

        /// <summary>
        /// Get sections of a course with completion checker
        /// </summary>
        /// <param name="courseId">Course ID to filter</param>
        /// <returns>A list of section basic dto objects</returns>
        [HttpGet("{courseId:int}/sections-study")]
        public async Task<ActionResult<List<SectionBasicDTO>>> GetCourseSectionsForStudy(int courseId)
        {
            return HandleResult(await _courseService.GetCourseSectionsForStudy(courseId));
        }

        /// <summary>
        /// This action method get course overview information for displaying in course study page.
        /// </summary>
        /// <param name="courseId">Course ID to filter</param>
        /// <returns>An course overview DTO object.</returns>
        [HttpGet("{courseId:int}/overview")]
        public async Task<IActionResult> GetCourseOverviewForStudy(int courseId)
        {
            return HandleResult(await _courseService.GetCourseOverviewDTOAsync(courseId));
        }
        /// <summary>
        /// API Get top course for Instructor page
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns></returns>
        [HttpGet("{instructorId}/get-top-course")]
        public async Task<IActionResult> GetTopCourseForAnalyic(int instructorId)
        {
            var course = await _courseService.GetTopCourseForAnalyic(instructorId);
            return HandleResult(course, LmsAction.Get);
        }

        /// <summary>
        /// Get Total Item Of Course: quiz + assignment + lesson.
        /// </summary>
        /// <returns>total item</returns>
        [HttpGet("total-item/{courseId}")]
        public async Task<IActionResult> GetTotalItemOfCourse(int courseId)
        {
            try
            {
                var total = await _courseService.GetTotalItemOfCourse(courseId);
                return HandleResult(total, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get Total Item Of Course in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Get Total Item completed Course of user: quiz + assignment + lesson.
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="courseID">courseID</param>
        /// <returns>total item completed</returns>
        [HttpGet("{courseID}/total-item-comleted-of-user/{userID}")]
        public async Task<IActionResult> GetTotalItemCompletedOfCourse(int userID, int courseID)
        {
            try
            {
                var total = await _courseService.GetTotalItemCompletedOfCourse(courseID, userID);
                return HandleResult(total, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get Total Item Completed Of Course in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Search Course
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchString([FromQuery] SearchRequest query)
        {
            return HandleResult(await _courseService.SearchCourse(query), LmsAction.Get);
        }
        /// <summary>
        /// Get newest course
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        [HttpGet("get-newest-course")]
        public async Task<IActionResult> GetNewestCourse([FromQuery] PagingRequest paging)
        {
            return HandleResult(await _courseService.GetNewestCourses(paging), LmsAction.Get);
        }
        /// <summary>
        /// Get the most sold course in this month
        /// </summary>
        /// <param name="paging"></param>
        /// <returns>List CourseDTO</returns>
        [HttpGet("get-feature-course")]
        public async Task<IActionResult> GetFeatureCourse([FromQuery] PagingRequest paging)
        {
            return HandleResult(await _courseService.GetFeaturedCoursesInThisMonth(paging), LmsAction.Get);
        }

        /// <summary>
        /// Check draft course of user on a day
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>true if user have any draft course and false if none</returns>
        [HttpGet]
        [Route("check-draft")]
        public async Task<IActionResult> CheckDraftCourseOfDay(int userId)
        {
            return HandleResult(await _courseService.CheckDraftCourseOfDay(userId), LmsAction.Get);
        }

        /// <summary>
        /// Create new course and mark draft
        /// </summary>
        /// <param name="courseCreateBasic"></param>
        /// <returns>New draft course Id</returns>
        [HttpPost]
        [Authorize]
        [Route("draft")]
        public async Task<IActionResult> CreateCourseBasic(CourseCreateDTO courseCreateBasic)
        {
            try
            {
                return HandleResult(await _courseService.CreateCourseBasic(courseCreateBasic), LmsAction.Add);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException.Message);
            }
        }

        /// <summary>
        /// Update media for create draft course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mediaCreate"></param>
        /// <returns>true if success and false if fail</returns>
        [HttpPut]
        [Authorize]
        [Route("draft/{id}/media")]
        public async Task<IActionResult> CreateCourseMedia(int id, CourseMediaCreateDTO mediaCreate)
        {
            try
            {
                return HandleResult(await _courseService.CreateCourseMedia(id, mediaCreate), LmsAction.Update);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException.Message);
            }
        }

        /// <summary>
        /// Update price for create draft course
        /// </summary>
        /// <param name="id"></param>
        /// <param name="priceCreate"></param>
        /// <returns>true if success and false if fail</returns>
        [HttpPut]
        [Authorize]
        [Route("draft/{id}/price")]
        public async Task<IActionResult> CreateCoursePrice(int id, CoursePriceCreateDTO priceCreate)
        {
            try
            {
                return HandleResult(await _courseService.CreateCoursePrice(id, priceCreate), LmsAction.Update);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException.Message);
            }
        }

        /// <summary>
        /// Api to change draft course to pending 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if success and false if fail</returns>
        [HttpPut]
        [Authorize]
        [Route("draft/{id}/finish-create")]
        public async Task<IActionResult> CreateCourseToPending(int id)
        {
            try
            {
                return HandleResult(await _courseService.CreateCourse(id), LmsAction.Update);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.InnerException.Message);
            }
        }

        /// <summary>
        /// Get newest draft course 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>CourseCreateDTO</returns>
        [HttpGet]
        [Authorize]
        [Route("newest-draft/{userId}")]
        public async Task<IActionResult> GetNewestDraftOfDay(int userId)
        {
            return HandleResult(await _courseService.GetNewestDraftCourse(userId), LmsAction.Get);
        }

        /// <summary>
        /// Get all draft courses of user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List CourseDTO</returns>
        [HttpGet]
        [Authorize]
        [Route("draft-course/{userId}")]
        public async Task<IActionResult> GetAllDraftCourseOfUser(int userId)
        {
            return HandleResult(await _courseService.GetAllDraftCourseOfUser(userId), LmsAction.Get);
        }

        /// <summary>
        /// Get best selling courses
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns> List CourseTitlePriceDTO</returns>
        [HttpGet]
        [Route("best-selling-courses/{instructorId}")]
        public async Task<IActionResult> GetBestSellingCourse(int instructorId, [FromQuery] PagingRequest pagingRequest)
        {
            return HandleResult(await _courseService.TopCourseBuy(instructorId, pagingRequest), LmsAction.Get);
        }
    }
}
