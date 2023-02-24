using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.QuizDTOs;
using LMS.Model.Response.QuizDTOs;
using LMS.Model.Utilities;
using LMS.Service.Services.QuizServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : BaseController
    {
        private readonly IQuizServices _quizServices;
        private readonly ILogger<QuizzesController> _logger;
        private readonly ActionOptions _actionOptions;

        public QuizzesController(
           IQuizServices quizServices,
           ILogger<QuizzesController> logger, IOptionsSnapshot<ActionOptions> actionOptions)
        {
            _quizServices = quizServices;
            _logger = logger;
            _actionOptions = actionOptions.Value;
        }

        /// <summary>
        /// Get a Quiz with questions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult<QuizForSectionDTO>>> GetQuizDetails(int id)
        {
            try
            {
                var quizDetailDTO = await _quizServices.GetQuizDetailsAsync(id);
                return HandleResult(quizDetailDTO, _actionOptions.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetQuizDetails));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create a quiz for section
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost("sectionQuiz")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<QuizDTO>>> CreateQuizSection( QuizCreateDTO request)
        {
            try
            {
                var quizDTO = await _quizServices.CreateQuizSectionAsync(request);

                return HandleResult(quizDTO, _actionOptions.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateQuizSection));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Update quiz
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<bool>>> UpdateQuiz(int id, [FromForm] QuizEditDTO request)
        {
            try
            {
                return HandleResult(await _quizServices.UpdateQuizAsync(id, request), _actionOptions.Update);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateQuiz));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// delete quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<bool>>> DeleteQuiz(int id)
        {
            try
            {
                return HandleResult(await _quizServices.DeleteQuizAsync(id), _actionOptions.Delete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteQuiz));
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
