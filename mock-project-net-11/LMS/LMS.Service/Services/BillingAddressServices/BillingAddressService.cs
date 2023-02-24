using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.BillingAddressDTOs;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace LMS.Service.Services.BillingAddressServices
{
    public class BillingAddressService : IBillingAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BillingAddressService> _logger;

        public BillingAddressService(IUnitOfWork unitOfWork, ILogger<BillingAddressService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> UpdateAsync(int userId, BillingAddressEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = await _unitOfWork.BillingAddressRepository
                    .GetAsync(x => x.UserId == userId);
                if (entity == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(userId.ToString()));
                }

                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.AcademyName = request.AcademyName;
                entity.AddressLine1 = request.AddressLine1;
                entity.AddressLine2 = request.AddressLine2;
                entity.Country = request.Country;
                entity.City = request.City;
                entity.Province = request.Province;
                entity.PostalCode = request.PostalCode;
                entity.PhoneNumber = request.PhoneNumber;
                await _unitOfWork.BillingAddressRepository.UpdateAsync(entity);
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
