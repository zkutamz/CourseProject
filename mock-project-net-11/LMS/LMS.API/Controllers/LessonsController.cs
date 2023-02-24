using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.LessonDTOs;
using LMS.Repository.Paging;
using LMS.Service.Services.LessonServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    public class LessonsController : BaseController
    {
        private readonly ILessonServices _lessonServices;

        public LessonsController(
            ILessonServices lessonServices)
        {
            _lessonServices = lessonServices;
        }
        /// <summary>
        /// Get lesson
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLesson([FromQuery] PagingRequest request)
        {
            var lessons = await _lessonServices.GetLessonAsync(request);
            return HandleResult(lessons, LmsAction.Get);
        }
        /// <summary>
        /// Get lesson detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LessonDTO</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonDetail(int id)
        {
            var lesson = await _lessonServices.GetLessonDetailAsync(id);
            return HandleResult(lesson, LmsAction.Get);
        }
        /// <summary>
        /// Update lesson
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>true if success</returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, [FromForm] LessonEditDTO request)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException();
            return HandleResult(await _lessonServices.UpdateLessonAsync(id, request), LmsAction.Update);
        }
        /// <summary>
        /// Create lesson
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromBody] LessonCreateDTO request)
        {
            if (!ModelState.IsValid)
                throw new BadRequestException();
            return HandleResult(await _lessonServices.CreateLessonAsync(request), LmsAction.Add);
        }
        /// <summary>
        /// Delete lesson
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if success</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            return HandleResult(await _lessonServices.DeleteLessonAsync(id), LmsAction.Delete);
        }
        /// <summary>
        /// Get lesson by Section Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="sectionId"></param>
        /// <returns></returns>
        [HttpGet("lesson-by-sectionId")]
        public async Task<IActionResult> GetLessonBySectionId([FromQuery] PagingRequest request, int sectionId)
        {
            return HandleResult(await _lessonServices.GetLessonBySectionId(sectionId, request));
        }

    }
}
