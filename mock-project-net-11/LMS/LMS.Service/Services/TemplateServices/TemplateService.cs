using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.TemplateDTOs;
using LMS.Model.Response.TemplateDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Services.HanleCertificateServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.TemplateServices
{
    public class TemplateService : ITemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly ILogger<TemplateService> _logger;
        private readonly IMapper _mapper;
        private readonly IHanleCertificateFilesServices _handleCertificateService;
        private readonly ResponseMessageOptions _responseMessage;
        public TemplateService(IUnitOfWork unitOfWork
            , ILogger<TemplateService> logger
            , IMapper mapper,
            IHanleCertificateFilesServices handleCertificateService,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage
            )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _handleCertificateService = handleCertificateService;
            _responseMessage = responseMessage.Value;
        }

        public async Task<TemplateDTO> GetTemplateAsync(int templateId)
        {
            var template = await _unitOfWork.TemplateRepository.GetAsync(z => z.Id == templateId && z.IsDelete == false);
            if (template == null) throw new NotFoundException(_responseMessage.NotFound);
            var templateDTO = _mapper.Map<TemplateDTO>(template);
            return templateDTO;
        }
        public async Task<PagingResult<TemplateDTO>> GetTemplatesAsync(PagingRequest pagingRequest)
        {
            var templates = await _unitOfWork.TemplateRepository.GetAllAsync(pagingRequest, x => x.IsDelete == false);
            if (templates.Count == 0) throw new NotFoundException(_responseMessage.NotFound);
            var templateDTO = _mapper.Map<PaginatedList<TemplateDTO>>(templates);
            var pagingResult = new PagingResult<TemplateDTO>()
            {
                PageSize = templateDTO.PageSize,
                CurrentPage = templateDTO.CurrentPage,
                TotalCount = templateDTO.TotalCount,
                TotalPages = templateDTO.TotalPages,
                Objects = templateDTO
            };
            return pagingResult;
        }


        public async Task<bool> CreateTemplateAsync(TemplateCreateDTO templateCreateDTO)
        {
            var templateUrl = await _handleCertificateService.SaveFileAsync(templateCreateDTO.TemplateData, "Certificates", "Templates");
            if (string.IsNullOrEmpty(templateUrl)) throw new NotFoundException(_responseMessage.NotFound);
            var template = _mapper.Map<Template>(templateCreateDTO);
            template.TemplateUrl = templateUrl;

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var addResult = await _unitOfWork.TemplateRepository.AddAsync(template);
                var saveresult = await _unitOfWork.SaveAsync();
                if (!addResult || saveresult == 0)
                {
                    throw new ConflictException(_responseMessage.UpdateFailure);
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
        public async Task<bool> UpdateTemplateAsync(int templateId, TemplateEditDTO templateEditDTO)
        {
            var existedTemplate = await _unitOfWork.TemplateRepository.GetAsync(x => x.Id == templateId && x.IsDelete == false);
            if (existedTemplate == null)
            {
                throw new NotFoundException(_responseMessage.NotFound);
            }
            if (templateId != existedTemplate.Id)
            {
                throw new BadRequestException(_responseMessage.NotMatch);
            }
            var templateUrl = await _handleCertificateService.SaveFileAsync(templateEditDTO.TemplateData,"Certificates", "Templates");
            var template = _mapper.Map<Template>(templateEditDTO);
            template.TemplateUrl = templateUrl;
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updateResult = await _unitOfWork.TemplateRepository.UpdateAsync(template);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                {
                    throw new ConflictException(_responseMessage.UpdateFailure);
                }
                await _handleCertificateService.DeleteFileAsync(existedTemplate.TemplateUrl);
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
        public async Task<bool> SoftDeleteTemplateAsync(int templateId)
        {
            var template = await _unitOfWork.TemplateRepository.GetAsync(x => x.Id == templateId && x.IsDelete == false);
            if (template == null) throw new NotFoundException(_responseMessage.NotFound);
            template.IsDelete = true;
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updateResult = await _unitOfWork.TemplateRepository.UpdateAsync(template);
                var saveResult = await _unitOfWork.SaveAsync();
                if (!updateResult || saveResult == 0)
                    throw new ConflictException(_responseMessage.DeleteFailure);
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
       
    }
}
