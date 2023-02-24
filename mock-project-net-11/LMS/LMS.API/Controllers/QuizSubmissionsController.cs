using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Model.Utilities;
using LMS.Service.Services.QuizSubmissionServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizSubmissionsController : BaseController
    {
        private readonly IQuizSubmissionServices _quizSubmissionServices;
        private readonly ILogger<QuizSubmissionsController> _logger;

        public QuizSubmissionsController(
           IQuizSubmissionServices quizSubmissionServices,
           ILogger<QuizSubmissionsController> logger)
        {
            _quizSubmissionServices = quizSubmissionServices;
            _logger = logger;
        }

        /// <summary>
        /// Get All QuizSubmission of user with quizID.
        /// </summary>
        /// <param name="userID">userID</param>
        /// <param name="quizID">quizID</param>
        /// <returns>QuizSubmissionDTOs</returns>
        [HttpGet("get-all-quiz-submission/{userID}/{quizID}")]
        public async Task<IActionResult> GetAllQuizSubmission(int userID, int quizID)
        {
            try
            {
                var result = await _quizSubmissionServices.GetAllQuizSubmissions(userID, quizID);
                if (result.Count == 0)
                {
                    throw new BadRequestException(ResponseMessage.GetDataFailed);
                }
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Check Quiz Submission Completed in API");
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Check QuizSubmission to confirm user completed the quiz of Section
        /// </summary>
        /// <param name="checkStatusStudyDTO">CheckStatusStudyDTO</param>
        /// <returns>true: completed | false: in progress </returns>
        [HttpGet("check-quiz-submission-completed")]
        public async Task<IActionResult> CheckQuizSubmissionCompleted([FromQuery] CheckStatusStudyDTO checkStatusStudyDTO)
        {
            try
            {
                var result = await _quizSubmissionServices.CheckQuizSubmissionCompleted(checkStatusStudyDTO);
                return HandleResult(result, LmsAction.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Check Quiz Submission Completed in API");
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// Haldle QuizSubmission after user completed the Quiz, Caculate quiz, create quiz submission, create answer
        /// </summary>
        /// <param name="userAnswerDTO">QuizSubmissionCreateDTO</param>
        /// <returns>QuizsubmissionDTO</returns>
        [HttpPost("handle-quiz-submission")]
        public async Task<ActionResult<ResponseResult<QuizSubmissionDTO>>> HandleQuizSubmission([FromBody] UserAnswersDTO userAnswerDTO)
        {
            try
            {
                var result = await _quizSubmissionServices.HandleQuizResult(userAnswerDTO);
                if (result == null)
                {
                    throw new BadRequestException(ResponseMessage.AddFailure);
                }
                return HandleResult(result, LmsAction.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Handle Quiz Submission in API");
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
