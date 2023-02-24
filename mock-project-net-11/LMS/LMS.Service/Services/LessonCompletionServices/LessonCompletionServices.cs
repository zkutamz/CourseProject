using AutoMapper;
using LMS.Model.Request.CommonDTOs;
using LMS.Model.Request.LessonCompletionDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.LessonCompletionServices
{
    public class LessonCompletionServices : ILessonCompletionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LessonCompletionServices> _logger;
        private readonly IMapper _mapper;

        public LessonCompletionServices(IUnitOfWork unitOfWork, ILogger<LessonCompletionServices> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<bool> CheckLessonCompleted(CheckStatusStudyDTO checkStatusStudyDTO)
        {
            try
            {
                var result = await _unitOfWork.LessonCompletionRepository.ExistsAsync(l=> 
                l.UserId== checkStatusStudyDTO.UserID && l.LessonId== checkStatusStudyDTO.TypeCheckID);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Check Lesson Completion Completed", nameof(CheckLessonCompleted));
                throw;
            }
        }
        
        public async Task<bool> CreateLessonCompletion(LessonCompletionCreateDTO lessonCompletionCreateDTO)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var lessonCompletion = _mapper.Map<LessonCompletion>(lessonCompletionCreateDTO);
                lessonCompletion.CreatedAt = lessonCompletion.UpdatedAt = lessonCompletion.CompletedDate = DateTime.Now;
                var result = await _unitOfWork.LessonCompletionRepository.AddAsync(lessonCompletion);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "Create Lesson Completion failed in service", nameof(CreateLessonCompletion));
                throw;
            }
        }

    }
}
