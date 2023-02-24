using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.CertificateCategoryDTOs;
using LMS.Model.Response.CertificateCategoryDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.CertificateCategoryServices
{
    public class CertificateCategoryService : ICertificateCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CertificateCategoryService> _logger;
        public CertificateCategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CertificateCategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<CertificateCategoryDTO> GetCertificateCategoryById(int certificateCategoryId)
        {
            var certificateCategory = (await _unitOfWork.CertificateCategoryRepository.GetAsync(x => x.Id == certificateCategoryId && x.IsDelete == false));
            if (certificateCategory == null)
            {
                throw new NotFoundException();
            }
            var certificateCategoryDto = _mapper.Map<CertificateCategoryDTO>(certificateCategory);
            return certificateCategoryDto;
        }

        public async Task<PagingResult<CertificateCategoryDTO>> GetCertificateCategories(PagingRequest pagingRequest)
        {
            var certificateCategories = await _unitOfWork.CertificateCategoryRepository.GetAllAsync(pagingRequest, x => x.IsDelete == false);
            var certificateCategoriesDto = _mapper.Map<PaginatedList<CertificateCategory>, PaginatedList<CertificateCategoryDTO>>(certificateCategories);

            var pagingResult = new PagingResult<CertificateCategoryDTO>()
            {
                TotalPages = certificateCategoriesDto.TotalPages,
                PageSize = certificateCategories.PageSize,
                TotalCount = certificateCategories.TotalCount,
                CurrentPage = certificateCategories.CurrentPage,
                Objects = certificateCategoriesDto
            };
            return pagingResult;
        }
        public async Task<bool> CreateCertificateCategoryAsync(CertificateCategoryCreateDTO certificateCategoryCreateDto)
        {
            var certificateCategory = _mapper.Map<CertificateCategory>(certificateCategoryCreateDto);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isSuccess = await _unitOfWork.CertificateCategoryRepository.AddAsync(certificateCategory);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!isSuccess || saveResult == 0) throw new ConflictException();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exeption)
            {
                _logger.LogError(exeption.Message, nameof(CertificateCategoryService));
                _logger.LogInformation(exeption.Message, nameof(CertificateCategoryService));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateCertificateCategoryAsync(CertificateCategoryEditDTO certificateCategoryEditDto)
        {
            var existedCertificateCategory = await _unitOfWork.CertificateCategoryRepository.GetAsync(x => x.Id == certificateCategoryEditDto.Id);
            if (existedCertificateCategory == null)
            {
                throw new NotFoundException();
            }
            var ceritificateCategory = _mapper.Map<CertificateCategory>(certificateCategoryEditDto);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var isSuccess = await _unitOfWork.CertificateCategoryRepository.UpdateAsync(ceritificateCategory);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!isSuccess || saveResult == 0) throw new ConflictException();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, nameof(CertificateCategoryService));
                _logger.LogInformation(exception.Message, nameof(CertificateCategoryService));
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> SoftDeleteCertificateCategoryAsync(int ceritificateCategoryId)
        {
            var existedCertificateCategory = await _unitOfWork.CertificateCategoryRepository.GetAsync(x => x.Id == ceritificateCategoryId);
            if (existedCertificateCategory == null)
            {
                throw new NotFoundException();
            }
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                existedCertificateCategory.IsDelete = true;
                var updateResult = await _unitOfWork.CertificateCategoryRepository.UpdateAsync(existedCertificateCategory);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                {
                    throw new ConflictException();
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, nameof(CertificateCategoryService));
                _logger.LogInformation(exception.Message, nameof(CertificateCategoryService));
                await transaction.RollbackAsync();
                throw;
            }
        }


    }
}
