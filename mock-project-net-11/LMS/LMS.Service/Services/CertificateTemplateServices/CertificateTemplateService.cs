using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.CertificateTemplateDTOs;
using LMS.Model.Response.TemplateDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.HanleCertificateServices;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
namespace LMS.Service.Services.CertificateTemplateServices
{
    public class CertificateTemplateService : ICertificateTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly ILogger<CertificateTemplateService> _logger;
        private readonly IMapper _mapper;
        private readonly IHanleCertificateFilesServices _handleCertificateService;
        public CertificateTemplateService(IUnitOfWork unitOfWork
            , ILogger<CertificateTemplateService> logger
            , IMapper mapper,
            IHanleCertificateFilesServices handleCertificateService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _handleCertificateService = handleCertificateService;
        }

        public async Task<TemplateDTO> GetCertificateTemplateAsync(int certificateTemplateId)
        {
            var certificateTemplate = await _unitOfWork.CertificateTemplateRepository.GetAsync(z => z.Id == certificateTemplateId && z.IsDelete == false);
            if (certificateTemplate == null) throw new NotFoundException();
            var certificateTemplateDTO = _mapper.Map<TemplateDTO>(certificateTemplate);
            return certificateTemplateDTO;
        }
        public async Task<PagingResult<TemplateDetailDTO>> GetCertificateTemplatesAsync(PagingRequest pagingRequest)
        {
            var certificateTemplates = await _unitOfWork.CertificateTemplateRepository.GetAllAsync(pagingRequest, x => x.IsDelete == false);
            if (certificateTemplates.Count == 0) throw new NotFoundException();
            var certificateTemplateDetailsDTO = _mapper.Map<PaginatedList<TemplateDetailDTO>>(certificateTemplates);
            var pagingResult = new PagingResult<TemplateDetailDTO>()
            {
                PageSize = certificateTemplateDetailsDTO.PageSize,
                CurrentPage = certificateTemplateDetailsDTO.CurrentPage,
                TotalCount = certificateTemplateDetailsDTO.TotalCount,
                TotalPages = certificateTemplateDetailsDTO.TotalPages,
                Objects = certificateTemplateDetailsDTO
            };
            return pagingResult;
        }


        public async Task<bool> CreateCertificateTemplateAsync(CertificateTemplateCreateDTO certificateTemplateCreateDTO)
        {
            var templateUrl = await _handleCertificateService.SaveFileAsync(certificateTemplateCreateDTO.TemplateData, "Certificates", "CertificateTemplates", "templates");
            if (string.IsNullOrEmpty(templateUrl)) throw new NotFoundException();
            var certificateTemplate = _mapper.Map<Template>(certificateTemplateCreateDTO);
            certificateTemplate.TemplateUrl = templateUrl;

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var addResult = await _unitOfWork.CertificateTemplateRepository.AddAsync(certificateTemplate);
                var saveresult = await _unitOfWork.SaveAsync();
                if (!addResult || saveresult == 0)
                {
                    throw new ConflictException();
                }
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                _logger.LogError(exeption.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> SoftDeleteCertificateTemplateAsync(int certificateTemplateId)
        {
            var certificateTemplate = await _unitOfWork.CertificateTemplateRepository.GetAsync(x => x.Id == certificateTemplateId && x.IsDelete == false);
            if (certificateTemplate == null) throw new NotFoundException();
            certificateTemplate.IsDelete = true;
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updateResult = await _unitOfWork.CertificateTemplateRepository.UpdateAsync(certificateTemplate);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                    throw new ConflictException();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                _logger.LogError(exception.Message);
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<bool> UpdateCertificateTemplateAsync(int certificateTemplateId, CertificateTemplateEditDTO certificateTemplateEditDTO)
        {
            var existedTemplate = await _unitOfWork.CertificateTemplateRepository.GetAsync(x => x.Id == certificateTemplateId && x.IsDelete == false);
            if (existedTemplate == null)
            {
                throw new NotFoundException();
            }
            if (certificateTemplateId != existedTemplate.Id)
            {
                throw new BadRequestException();
            }
            var templateUrl = await Utilities.FileHelper.SaveFile(certificateTemplateEditDTO.TemplateData);
            var certificateTemplate = _mapper.Map<Template>(certificateTemplateEditDTO);
            certificateTemplate.TemplateUrl = templateUrl;
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updateResult = await _unitOfWork.CertificateTemplateRepository.UpdateAsync(certificateTemplate);
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
                _logger.LogInformation(exception.Message);
                _logger.LogError(exception.Message);
                await transaction.CommitAsync();
                throw;
            }
        }
    }
}
