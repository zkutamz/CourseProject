using AutoMapper;
using LMS.Model.Request.AnswerDTOs;
using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.QuizSubmissionDTOs;
using LMS.Model.Response.AnswerDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Model.Response.QuizSubmissionDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.AnswerServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.QuizSubmissionServices
{
    public class QuizSubmissionServices : IQuizSubmissionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QuizSubmissionServices> _logger;
        private readonly IAnswerServices _answerServices;
        private readonly IMapper _mapper;

        public QuizSubmissionServices(IUnitOfWork unitOfWork, ILogger<QuizSubmissionServices> logger,
            IAnswerServices answerServices
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _answerServices = answerServices;
            _mapper = mapper;
        }
        public async Task<bool> CheckQuizSubmissionCompleted(CheckStatusStudyDTO checkStatusStudyDTO)
        {
            try
            {
                var quizSubmissionDTO = _mapper.Map<List<QuizSubmissionDTO>>(
                    await _unitOfWork.QuizSubmissionRepository.GetAllQuizSubmission(checkStatusStudyDTO.UserID, checkStatusStudyDTO.TypeCheckID));
                return quizSubmissionDTO.Count > 0 && quizSubmissionDTO[0].IsPassed;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Check Quiz Submission Completed", nameof(CheckQuizSubmissionCompleted));
                throw;
            }
        }
        public async Task<int> CreateQuizSubmission(QuizSubmissionCreateDTO quizSubmissionCreateDTO)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var quizSubmission = _mapper.Map<QuizSubmission>(quizSubmissionCreateDTO);
                quizSubmission.CreatedAt = quizSubmission.UpdatedAt = quizSubmission.SubmitDate = DateTime.Now;
                quizSubmission.IsCompleted = true;
                var result = await _unitOfWork.QuizSubmissionRepository.AddAsync(quizSubmission);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                if (result)
                {
                    return quizSubmission.Id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Notification failed in service", nameof(CreateQuizSubmission));
                throw;
            }
        }

        public async Task<QuizSubmissionDTO> HandleQuizResult(UserAnswersDTO request)
        {
            try
            {
                // Caculate Quiz
                var quizSubmissionCreateDTO = await CaculateQuizAsync(request);
                // Create quiz submission
                var quizSubmissionID = await CreateQuizSubmission(quizSubmissionCreateDTO);
                if (quizSubmissionID > 0)
                {
                    // Create Anwser for quiz submission
                    var listAnwser = await GetListAnwserAsync(request);
                    await CreateListAnwserForQuizSubmissionAsync(listAnwser, quizSubmissionID);
                    // Get detail Quiz submission by ID
                    var quizSubmissionDTO = await GetQuizSubmissionByID(quizSubmissionID);
                    return quizSubmissionDTO;
                }
                else
                {
                    _logger.LogError("Null data for QuizSubmissionDTO", "{0} {1}", "Handle Quiz Result in service", nameof(HandleQuizResult));
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Handle Quiz Result failed in service", nameof(HandleQuizResult));
                throw;
            }
        }

        /// <summary>
        /// Create List Anwser For Quiz Submission
        /// </summary>
        /// <param name="listAnwser">List<AnswerCreateDTO> listAnwser</param>
        /// <param name="quizSumissionID">quizSumissionID</param>
        /// <returns>List<AnswerDTO></returns>
        private async Task<List<AnswerDTO>> CreateListAnwserForQuizSubmissionAsync(List<AnswerCreateDTO> listAnwser, int quizSumissionID)
        {
            foreach (var item in listAnwser)
            {
                item.QuizSubmissionId = quizSumissionID;
            }
            var listAnswerDTO = await _answerServices.CreateAnswersAsync(listAnwser);
            return listAnswerDTO;
        }

        /// <summary>
        /// Get List Anwser Async
        /// </summary>
        /// <param name="request">UserAnswersDTO</param>
        /// <returns>List<AnswerCreateDTO></returns>
        private async Task<List<AnswerCreateDTO>> GetListAnwserAsync(UserAnswersDTO request)
        {
            var list = new List<AnswerCreateDTO>();
            foreach (var answer in request.Answers)
            {
                var quizQuestionMarkDTO = _mapper.Map<QuizQuestionMarkDTO>(await _unitOfWork.QuizQuestionRepository.GetAsync(q => q.Id == answer.QuizQuestionId));
                var answerCreateDTO = new AnswerCreateDTO()
                {
                    Content = answer.Content,
                    QuizQuestionId = quizQuestionMarkDTO.Id,
                };
                list.Add(answerCreateDTO);
            }
            return list;
        }

        /// <summary>
        /// Caculate Quiz: corectAnswer, wrongAnswer, TotalQuestion, IsPassed
        /// </summary>
        /// <param name="request">UserAnswersDTO request</param>
        /// <returns>QuizSubmissionCreateDTO</returns>
        private async Task<QuizSubmissionCreateDTO> CaculateQuizAsync(UserAnswersDTO request)
        {
            var quizSubmissionCreateDTO = new QuizSubmissionCreateDTO();
            quizSubmissionCreateDTO.UserId = request.AppUserId;
            quizSubmissionCreateDTO.QuizId = request.QuizId;
            int corectAnswer = 0, wrongAnswer = 0;
            foreach (var answer in request.Answers)
            {
                var quizQuestionMarkDTO = _mapper.Map<QuizQuestionMarkDTO>(await _unitOfWork.QuizQuestionRepository.GetAsync(q => q.Id == answer.QuizQuestionId));
                if (answer.Content.Equals(quizQuestionMarkDTO.Answer))
                {
                    corectAnswer++;
                }
                else
                {
                    wrongAnswer++;
                }
            }
            quizSubmissionCreateDTO.CorectAnswers = corectAnswer;
            quizSubmissionCreateDTO.WrongAnswers = wrongAnswer;
            quizSubmissionCreateDTO.TotalQuestion = corectAnswer + wrongAnswer;
            quizSubmissionCreateDTO.IsPassed = CheckPassQuiz(corectAnswer + wrongAnswer, corectAnswer);
            return quizSubmissionCreateDTO;
        }

        /// <summary>
        /// Check Pass Quiz. Percent > 0.8 ? pass : failed
        /// </summary>
        /// <param name="total">int total question</param>
        /// <param name="correct">int correct question</param>
        /// <returns>true: pass, false: failed</returns>
        private bool CheckPassQuiz(int total, int correct)
        {
            double percent = correct / total;
            var isPass = percent < 0.8 ? false : true;
            return isPass;
        }

        public async Task<QuizSubmissionDTO> GetQuizSubmissionByID(int quizSubmissionID)
        {
            try
            {
                var quizSubmissionDTO = _mapper.Map<QuizSubmissionDTO>(await _unitOfWork.QuizSubmissionRepository.GetQuizSubmissionByID(quizSubmissionID));
                return quizSubmissionDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get Quiz Submission By ID failed in service", nameof(GetQuizSubmissionByID));
                throw;
            }
        }

        public async Task<List<QuizSubmissionDTO>> GetAllQuizSubmissions(int userID, int quizID)
        {
            try
            {
                var quizSubmissionDTOs = _mapper.Map<List<QuizSubmissionDTO>>(await _unitOfWork.QuizSubmissionRepository.GetAllQuizSubmission(userID, quizID));
                return quizSubmissionDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get All Quiz Submissions failed in service", nameof(GetAllQuizSubmissions));
                throw;
            }
        }
    }
}