using System;
using System.Threading.Tasks;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.NotificationSettingDTOs;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace LMS.Service.Services.NotificationSettingServices
{
    public class NotificationSettingService : INotificationSettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NotificationSettingService> _logger;

        public NotificationSettingService(IUnitOfWork unitOfWork, ILogger<NotificationSettingService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<bool> UpdateAsync(int userId, NotificationSettingEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = await _unitOfWork.NotificationSettingRepository
                    .GetAsync(x => x.UserId == userId);
                if (entity == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(userId.ToString()));
                }

                entity.ActivityOnMyComment = request.ActivityOnMyComment;
                entity.RecommendedCourses = request.RecommendedCourses;
                entity.RepliesToMyComments = request.RepliesToMyComments;
                entity.Subscriptions = request.Subscriptions;
                await _unitOfWork.NotificationSettingRepository.UpdateAsync(entity);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in {nameof(UpdateAsync)}. {e.Message}");
                await trans.RollbackAsync();
                throw new BadRequestException($"Something went wrong in {nameof(UpdateAsync)}. {e.Message}");
            }
            
        }
    }
}
