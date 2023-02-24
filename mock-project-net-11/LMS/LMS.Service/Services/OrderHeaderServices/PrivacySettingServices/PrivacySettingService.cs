using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.PrivacySettingDTOs;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.PrivacySettingServices
{
    public class PrivacySettingService : IPrivacySettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PrivacySettingService> _logger;

        public PrivacySettingService(IUnitOfWork unitOfWork, ILogger<PrivacySettingService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> UpdateAsync(int userId, PrivacySettingEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = await _unitOfWork.PrivacySettingRepository
                    .GetAsync(x => x.UserId == userId);
                if (entity == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(userId.ToString()));
                }

                entity.ShowCoursesYouAreTakingOnYourProfilePage = request.ShowCoursesYouAreTakingOnYourProfilePage;
                entity.ShowYourProfileOnSearchEngines = request.ShowYourProfileOnSearchEngines;
                await _unitOfWork.PrivacySettingRepository.UpdateAsync(entity);
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
