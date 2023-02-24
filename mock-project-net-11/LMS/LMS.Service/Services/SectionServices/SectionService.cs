using AutoMapper;
using LMS.Model.Exceptions;
using LMS.Model.Request.SectionDTOs;
using LMS.Model.Response.SectionDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Options;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.SectionServices
{
    public class SectionService : ISectionService
    {
        private readonly ILogger<SectionService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ResponseMessageOptions _responseMessage;
        private readonly IUserAccessor _userAccessor;

        public SectionService(
            ILogger<SectionService> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IOptionsSnapshot<ResponseMessageOptions> responseMessage,
            IUserAccessor userAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userAccessor = userAccessor;
            _responseMessage = responseMessage.Value;
        }

        public async Task<PagingResult<SectionDTO>> GetSectionDTOsAsync(PagingRequest request = null)
        {
            try
            {
                request ??= new PagingRequest();

                var sections = await _unitOfWork.SectionRepository.GetAllAsync(request);

                var sectionDTOs = _mapper.Map<PaginatedList<Section>, PaginatedList<SectionDTO>>(sections);

                return new PagingResult<SectionDTO>
                {
                    CurrentPage = sectionDTOs.CurrentPage,
                    TotalPages = sectionDTOs.TotalPages,
                    PageSize = sectionDTOs.PageSize,
                    TotalCount = sectionDTOs.TotalCount,
                    Objects = sectionDTOs
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetSectionDTOsAsync));
                throw;
            }
        }

        public async Task<SectionDetailDTO> GetSectionDetailDTOAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var section = await _unitOfWork.SectionRepository.GetAsync(s => s.Id == id && s.IsDelete == false);

                if (section is null)
                    throw new NotFoundException(_responseMessage.GetDataFailed);

                return _mapper.Map<SectionDetailDTO>(section);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(GetSectionDetailDTOAsync));
                throw;
            }
        }

        public async Task<SectionDTO> CreateSectionAsync(SectionCreateDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var section = _mapper.Map<Section>(request);

                var result = await _unitOfWork.SectionRepository.AddAsync(section);

                if (result is false)
                    throw new BadRequestException(_responseMessage.AddFailure);

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();

                var sectionDTO = _mapper.Map<SectionDTO>(section);
                return sectionDTO;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateSectionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task CreateSectionsAsync(List<SectionCreateDTO> requests)
        {
            try
            {
                foreach (var request in requests)
                {
                    var result = await CreateSectionAsync(request);

                    if (result is null)
                        throw new BadRequestException(_responseMessage.ErrorOccurred);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(CreateSectionsAsync));
                throw;
            }
        }

        public async Task<bool> UpdateSectionAsync(SectionEditDTO request)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var section = await _unitOfWork.SectionRepository.GetAsync(s => s.Id == request.Id);

                if (section is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                _mapper.Map(request, section);

                var result = await _unitOfWork.SectionRepository.UpdateAsync(section);

                if (result is false)
                    throw new BadRequestException(_responseMessage.UpdateFailure);

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(UpdateSectionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<int> UpdateSectionTotalTimeAsync(int sectionId, int totalTime)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (sectionId <= 0 || totalTime < 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var section = await _unitOfWork.SectionRepository.GetAsync(s => s.Id == sectionId);

                if (section is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                section.TotalTime += totalTime;

                var result = await _unitOfWork.SectionRepository.UpdateAsync(section);

                if (result)
                {
                    await _unitOfWork.SaveAsync();
                }

                return section.TotalTime;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(UpdateSectionAsync));
                await transaction.RollbackAsync();
                await transaction.DisposeAsync();
                throw;
            }
        }

        public async Task<bool> DeleteSectionAsync(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id <= 0)
                    throw new BadRequestException(_responseMessage.InvalidParameters);

                var section = await _unitOfWork.SectionRepository.GetAsync(s => s.Id == id);

                if (section is null)
                    throw new NotFoundException(_responseMessage.NotFound);

                section.IsDelete = true;

                var result = await _unitOfWork.SectionRepository.UpdateAsync(section);

                if (result is false)
                    throw new BadRequestException();

                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(DeleteSectionAsync));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> IsExistsAsync(int sectionId)
        {
            try
            {
                return await _unitOfWork.SectionRepository.ExistsAsync(c => c.Id == sectionId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{0} in {1}", _responseMessage.ErrorOccurred, nameof(IsExistsAsync));
                throw;
            }
        }
    }
}