using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.LessonCompletionDTOs;
using LMS.Service.Services.LessonCompletionServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonCompletionsController : BaseController
    {
        private readonly ILessonCompletionServices _lessonCompletionServices;
        private readonly ILogger<LessonCompletionsController> _logger;

        public LessonCompletionsController(ILessonCompletionServices lessonCompletionServices,
          ILogger<LessonCompletionsController> logger)
        {
            _lessonCompletionServices = lessonCompletionServices;
            _logger = logger;
        }
        /// <summary>
        /// Create Lesson completion after user completed the lesson
        /// </summary>
        /// <param name="lessonCompletionCreateDTO">lessonCompletionCreateDTO</param>
        /// <returns>true:success false: failed</returns>
        [HttpPost("create-lesson-completion")]
        public async Task<IActionResult> CreateLessonCompletion([FromBody] LessonCompletionCreateDTO lessonCompletionCreateDTO)
        {
            try
            {
                var result = await _lessonCompletionServices.CreateLessonCompletion(lessonCompletionCreateDTO);
                if (result == false)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Lesson Completion in API");
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// Check lesson completion to confirm user completed the lesson of Section
        /// </summary>
        /// <param name="checkStatusStudyDTO">checkStatusStudyDTO</param>
        /// <returns>true: completed
        ///          false: inprogress</returns>
        [HttpGet("check-lesson-completed")]
        public async Task<IActionResult> CheckLessonCompleted([FromQuery] CheckStatusStudyDTO checkStatusStudyDTO)
        {
            try
            {
                var result = await _lessonCompletionServices.CheckLessonCompleted(checkStatusStudyDTO);
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Check Lesson Completed in API");
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
