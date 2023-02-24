using AutoMapper;
using LMS.Model.Request.FeedbackDTOs;
using LMS.Model.Response.FeedbackDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Enums;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.FileStorageServices;
using LMS.Service.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.FeedbackServices
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<FeedbackService> logger;
        private readonly IFileStorageService fileStorageService;
       
        public FeedbackService(IUnitOfWork unitOfWork,
            IMapper mapper, 
            ILogger<FeedbackService> logger,
            IFileStorageService fileStorageService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.fileStorageService = fileStorageService;
        }
        public async Task<bool> CreateFeedbackAsync(FeedbackCreateDTO feedback)
        {
            var fileName = feedback.ScreenShot != null ? (await fileStorageService.SaveFile(feedback.ScreenShot)) : null;
            using var transition = await unitOfWork.BeginTransactionAsync();
            try
            {
                
                // create feedback
                var createFeedback = mapper.Map<Feedback>(feedback);
                // save screenshot
                createFeedback.ScreenShot = fileName;
                createFeedback.CreatedAt = DateTime.Now;
                createFeedback.UpdatedAt = DateTime.Now;
                createFeedback.IsDelete = false;
                createFeedback.Status = FeedbackStatus.Pending;
                createFeedback.Answer = "";
                var result = await unitOfWork.FeedbackRepository.AddAsync(createFeedback);
                await unitOfWork.SaveAsync();
                await transition.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                // delete screenShot
                await fileStorageService.DeleteFileAsync(fileName);
                await transition.RollbackAsync();
                logger.LogError(ex, "{0} {1}", "Create Feedback failed in service", nameof(CreateFeedbackAsync));
                throw;
            }
        }

        public async Task<PaginatedList<FeedbackDTO>> GetFeedbackAsyncPaging(PagingRequest request)
        {
            try
            {
                request ??= new PagingRequest();
                var feedbacks = mapper.Map<PaginatedList<FeedbackDTO>>( await unitOfWork.FeedbackRepository.GetAllFeedbackPaging(request));
                return feedbacks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAnswerFeedbackAsync(int id,FeedbackAnswerDTO feedback)
        {
            using var transition = await unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != feedback.Id) return false;
                // update feedback
                // var editFeedback = mapper.Map<Feedback>(feedback);
                var editFeedback = await unitOfWork.FeedbackRepository.GetFeedbackById(id);
                editFeedback.UpdatedAt = DateTime.Now;
                editFeedback.Answer = feedback.Answer;
                editFeedback.Status = feedback.Status;
                var result = await unitOfWork.FeedbackRepository.UpdateAsync(editFeedback);
                await unitOfWork.SaveAsync();
                await transition.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                await transition.RollbackAsync();
                logger.LogError(ex, "{0} {1}", "Update Feedback failed in service", nameof(UpdateAnswerFeedbackAsync));
                throw;
            }
        }

        public async Task<PaginatedList<FeedbackDTO>> GetFeedbackUserByIdAsyncPaging(int id, PagingRequest request)
        {
            try
            {
                request ??= new PagingRequest();
                var feedbacks = mapper.Map<PaginatedList<FeedbackDTO>>(await unitOfWork.FeedbackRepository.GetAllFeedbackUserByIdPaging(id,request));
                return feedbacks;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
