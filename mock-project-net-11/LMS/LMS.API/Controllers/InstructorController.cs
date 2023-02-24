using LMS.Model.Constant;
using LMS.Service.Services.InstructorServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController: BaseController
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        /// <summary>
        /// Get total course of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of coures</returns>
        [HttpGet("{instructorId}/GetTotalCourseOfAnInstructor")]
        public async Task<IActionResult> GetTotalCourseOfAnInstructor(int instructorId)
        {
            return HandleResult(await _instructorService.ToTalCoursesOfAnInstructorAsync(instructorId), LmsAction.Get);
        }
        /// <summary>
        /// Get total course reviews of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of coures's reviews</returns>
        [HttpGet("{instructorId}/GetTotalCourseReviewOfAnInstructor")]
        public async Task<IActionResult> GetTotalCourseReviewOfAnInstructor(int instructorId)
        {
            return HandleResult(await _instructorService.TotalCourseReviewOfAnInstructorAsync(instructorId), LmsAction.Get);
        }
        /// <summary>
        /// Get total course reviews of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of subscipter</returns>
        [HttpGet("{instructorId}/GetTotalSubscriptionOfAnInstructor")]
        public async Task<IActionResult> GetTotalSubscriptionOfAnInstructor(int instructorId)
        {
            return HandleResult(await _instructorService.TotalSubcriptionOfAnInstructorAsync(instructorId), LmsAction.Get);
        }
        /// <summary>
        /// Get total enrolled student of an instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns>Number of student</returns>
        [HttpGet("{instructorId}/GetTotalEnrollStudentsOfAnInstructor")]
        public async Task<IActionResult> GetTotalEnrollStudentsOfAnInstructor(int instructorId)
        {
            return HandleResult(await _instructorService.TotalEnrollStudentsOfAnInstructorAsync(instructorId), LmsAction.Get);
        }
        /// <summary>
        /// Get popular instructor by number student enrolled instructor's course
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("popular-instructors")]
        public async Task<IActionResult> PopularInstructor()
        {
            return HandleResult(await _instructorService.GetPopularInstructor(), LmsAction.Get);
        }
    }
}