using AutoMapper;
using ExcelDataReader;
using LMS.Model.Exceptions;
using LMS.Model.Request.QuizQuestionDTOs;
using LMS.Model.Response.QuizQuestionDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Services.QuizQuestionServices
{
    public class QuizQuestionServices : IQuizQuestionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QuizQuestionServices> _logger;
        private readonly IMapper _mapper;

        public QuizQuestionServices(IUnitOfWork unitOfWork, ILogger<QuizQuestionServices> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<QuizQuestionResponseDTO> CreateQuizQuestionAsync(QuizQuestionCreateDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var quizQuestion = _mapper.Map<QuizQuestion>(request);
                var result = await _unitOfWork.QuizQuestionRepository.AddAsync(quizQuestion);
                if (result)
                {
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new BadRequestException("add failed at QuizQuestion");
                }

                var quizQuestionDTO = _mapper.Map<QuizQuestionResponseDTO>(quizQuestion);
                if (quizQuestionDTO is null)
                    throw new BadRequestException();

                return quizQuestionDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(CreateQuizQuestionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<QuizQuestionResponseDTO>> CreateQuizQuestionsAsync(List<QuizQuestionCreateDTO> request)
        {
            //cannot attach 
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var quizQuestions = _mapper.Map<List<QuizQuestion>>(request);
                await _unitOfWork.QuizQuestionRepository.AddRangeAsync(quizQuestions);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                var quizQuestionsDTO = _mapper.Map<List<QuizQuestionResponseDTO>>(quizQuestions);

                if (quizQuestionsDTO is null)
                    throw new BadRequestException();

                return quizQuestionsDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(CreateQuizQuestionsAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> DeleteQuizQuestionAsync(int quizQuestionId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var quizQuestion = await _unitOfWork.QuizQuestionRepository.GetAsync(s => s.Id == quizQuestionId);

                if (quizQuestion is null)
                    throw new NotFoundException();

                quizQuestion.IsDelete = true;

                var result = await _unitOfWork.QuizQuestionRepository.UpdateAsync(quizQuestion);

                if (result is false)
                    throw new BadRequestException();

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(DeleteQuizQuestionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateQuizQuestionAsync(int quizQuestionId, QuizQuestionEditDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (quizQuestionId != request.Id)
                    throw new BadRequestException("Not Found");

                var quizQuestion = _mapper.Map<QuizQuestion>(request);

                var result = await _unitOfWork.QuizQuestionRepository.UpdateAsync(quizQuestion);

                if (result is false)
                    throw new BadRequestException();

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(UpdateQuizQuestionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<QuizQuestionDetailDTO> GetQuizQuestionDetailAsync(int quizQuestionId)
        {
            try
            {
                var quizQuestionDetail = await _unitOfWork.QuizQuestionRepository.GetQuizQuestionDetailAsync(quizQuestionId);           
                if (quizQuestionDetail is null) throw new NotFoundException("Not found");

                var quizQuestionDetailDTO = _mapper.Map<QuizQuestionDetailDTO>(quizQuestionDetail);
                return quizQuestionDetailDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetQuizQuestionDetailAsync));
                throw;
            }
        }

        public async Task<List<QuizQuestionResponseDTO>> CreateQuizQuestionFromFile(string fileName, int quizID)
        {
            try
            {
                //var fileName = fileExcel != null ? await FileHelper.SaveFile(fileExcel) : null;
                var quizQuestions = GetListQuizQuestion(fileName, quizID);
                var result = await CreateQuizQuestionsAsync(quizQuestions);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(CreateQuizQuestionFromFile));
                throw;
            }
        }
        /// <summary>
        /// Get List Quiz Question from file excel.
        /// </summary>
        /// <param name="fName">fName</param>
        /// <param name="quizID">quizID</param>
        /// <returns>QuizQuestionCreateDTO</returns>
        private List<QuizQuestionCreateDTO> GetListQuizQuestion(string fName, int quizID)
        {
            var list = new List<QuizQuestionCreateDTO>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot"}" + "\\" + fName;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        list.Add(new QuizQuestionCreateDTO()
                        {
                            Title = reader.GetValue(0).ToString(),
                            OptionA = reader.GetValue(1).ToString(),
                            OptionB = reader.GetValue(2).ToString(),
                            OptionC = reader.GetValue(3).ToString(),
                            OptionD = reader.GetValue(4).ToString(),
                            Answer = reader.GetValue(5).ToString(),
                            Explanation = reader.GetValue(6).ToString(),
                            QuizQuestionType = 0,
                            IsPublic = true,
                            QuizId = quizID
                        });
                    }
                }
            }
            return list;
        }
    }
}
