using LMS.API.Options;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.QuizQuestionDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Utilities;
using LMS.Service.Services.QuizQuestionServices;
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
    [ApiController]
    public class QuizQuestionsController : BaseController
    {
        private readonly IQuizQuestionServices _quizQuestionServices;
        private readonly ILogger<QuizQuestionsController> _logger;
        private readonly ActionOptions _actionOptions;

        public QuizQuestionsController(
           IQuizQuestionServices quizQuestionServices,
           ILogger<QuizQuestionsController> logger, IOptionsSnapshot<ActionOptions> actionOptions)
        {
            _quizQuestionServices = quizQuestionServices;
            _logger = logger;
            _actionOptions = actionOptions.Value;
        }

        /// <summary>
        /// Get Quiz Question Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult<QuizQuestionDetailDTO>>> GetQuizQuestionDetails(int id)
        {
            try
            {
                var quizQuestionDetailDTO = await _quizQuestionServices.GetQuizQuestionDetailAsync(id);
                return HandleResult(quizQuestionDetailDTO, _actionOptions.Get);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetQuizQuestionDetails));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create a Quiz Question
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<QuizQuestionResponseDTO>>> CreateQuizQuestion( QuizQuestionCreateDTO request)
        {
            try
            {
                /*if (ModelState.IsValid)
                    throw new BadRequestException();*/

                var quizQuestionsDTO = await _quizQuestionServices.CreateQuizQuestionAsync(request);

                return HandleResult(quizQuestionsDTO, _actionOptions.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateQuizQuestion));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Create a list questions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPost("list")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<List<QuizQuestionResponseDTO>>>> CreateQuizQuestions(List<QuizQuestionCreateDTO> request)
        {
            try
            {
                var quizQuestionsDTO = await _quizQuestionServices.CreateQuizQuestionsAsync(request);

                return HandleResult(quizQuestionsDTO, _actionOptions.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateQuizQuestions));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Update a Quiz
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<bool>>> UpdateQuizQuestion(int id, [FromForm] QuizQuestionEditDTO request)
        {
            try
            {
                return HandleResult(await _quizQuestionServices.UpdateQuizQuestionAsync(id, request), _actionOptions.Update);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateQuizQuestion));
                throw new BadRequestException(ex.Message);
            }
        }

        /// <summary>
        /// Solf delete a quiz
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.INSTRUCTOR)]
        public async Task<ActionResult<ResponseResult<bool>>> DeleteQuizQuestion(int id)
        {
            try
            {
                return HandleResult(await _quizQuestionServices.DeleteQuizQuestionAsync(id), _actionOptions.Delete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteQuizQuestion));
                throw new BadRequestException(ex.Message);
            }
        }
        /// <summary>
        /// Create Quiz Questions From File Excel
        /// </summary>
        /// <param name="fileExcel">fileExcel</param>
        /// <param name="quizID">quizID</param>
        /// <returns>quizQuestionsDTOs</returns>
        [HttpPost("import-file-quiz-question")]
        public async Task<IActionResult> CreateQuizQuestionsFromFileExcel(string fileExcel, int quizID)
        {
            try
            {
                var quizQuestionsDTOs = await _quizQuestionServices.CreateQuizQuestionFromFile(fileExcel, quizID);
                return HandleResult(quizQuestionsDTOs, _actionOptions.Add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateQuizQuestion));
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
