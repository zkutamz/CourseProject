using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.QuizDTOs;
using LMS.Model.Response.QuizDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.SectionServices;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.QuizServices
{
    public class QuizServices : IQuizServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QuizServices> _logger;
        private readonly IMapper _mapper;
        private readonly ISectionService _sectionService;

        public QuizServices(IUnitOfWork unitOfWork, ILogger<QuizServices> logger, IMapper mapper, ISectionService sectionService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _sectionService = sectionService;
        }

        public async Task<QuizDTO> CreateQuizSectionAsync(QuizCreateDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var quiz = _mapper.Map<Quiz>(request);
                var result = await _unitOfWork.QuizRepository.AddAsync(quiz);

                if (result)
                {
                    await _unitOfWork.SaveAsync();

                    var quizSection = new QuizSection
                    {
                        SectionId = request.SectionId,
                        QuizId = quiz.Id
                    };
                    var resultAddQuizSectionTable = await _unitOfWork.QuizSectionRepository.AddAsync(quizSection);
                    //update section total time
                    //var section = await _unitOfWork.SectionRepository.GetAsync(x => x.Id == request.SectionId);
                    //await _sectionService.UpdateSectionTotalTimeAsync(request.SectionId, section.TotalTime + request.TotalTime);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    throw new BadRequestException("add failed at CreateQuizSectionAsync");
                }

                var quizDTO = _mapper.Map<QuizDTO>(quiz);
                if (quizDTO is null)
                    throw new BadRequestException();

                return quizDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(CreateQuizSectionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteQuizAsync(int quizId)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (quizId <= 0)
                    throw new BadRequestException();

                var quiz = await _unitOfWork.QuizRepository.GetAsync(s => s.Id == quizId);
                var quizSection = await _unitOfWork.QuizSectionRepository.GetAsync(s=>s.QuizId == quizId);
                if (quizSection is null)
                    throw new NotFoundException();
                await _unitOfWork.QuizSectionRepository.RemoveAsync(quizSection);

                if (quiz is null)
                    throw new NotFoundException();

                quiz.IsDelete = true;


                var result = await _unitOfWork.QuizRepository.UpdateAsync(quiz);

                if (result is false)
                    throw new BadRequestException();

                var sectionId = await _unitOfWork.QuizSectionRepository.GetSectionId(quizId);

                //update section total time
                //var section = await _unitOfWork.SectionRepository.GetAsync(x => x.Id == sectionId);
                //await _sectionService.UpdateSectionTotalTimeAsync(sectionId, section.TotalTime - quiz.TotalTime);

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(DeleteQuizAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<QuizDTO> UpdateQuizAsync(int quizId, QuizEditDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (quizId != request.Id)
                    throw new BadRequestException();

                var oldQuiz = await _unitOfWork.QuizRepository.GetAsync(q => q.Id == request.Id);
                var oldQuizTime = oldQuiz.TotalTime;

                var quiz = _mapper.Map<Quiz>(request);

                var result = await _unitOfWork.QuizRepository.UpdateAsync(quiz);

                if (result is false)
                    throw new BadRequestException();


                //update section total time
                //var sectionId = await _unitOfWork.QuizSectionRepository.GetSectionId(quizId);
                //var section = await _unitOfWork.SectionRepository.GetAsync(x => x.Id == sectionId);
                //await _sectionService.UpdateSectionTotalTimeAsync(sectionId,section.TotalTime + quiz.TotalTime - oldQuizTime);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                var quizDTO = _mapper.Map<QuizDTO>(quiz);

                return quizDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(UpdateQuizAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<QuizForSectionDTO> GetQuizDetailsAsync(int quizId)
        {
            try
            {
                var quizDetail = await _unitOfWork.QuizRepository.GetAsync(x => x.Id == quizId, x => x.QuizQuestions);
                if (quizDetail is null) throw new NotFoundException("Not found");

                var quizDetailDTO = _mapper.Map<QuizForSectionDTO>(quizDetail);
                return quizDetailDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} {1}", "Something went wrong in ", nameof(GetQuizDetailsAsync));
                throw;
            }
        }
    }
}
