using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.HelpDTOs;
using LMS.Model.Response.HelpDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.HelpServices
{
    public class HelpService : IHelpService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HelpService> _logger;
        private readonly IMapper _mapper;

        public HelpService(IUnitOfWork unitOfWork, ILogger<HelpService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Create new help
        /// </summary>
        /// <param name="helpCreate"></param>
        /// <returns>New helpId</returns>
        public async Task<int> CreateHelp(HelpCreateDTO helpCreate)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var newHelp = _mapper.Map<Help>(helpCreate);
                newHelp.IsPublished = false;
                await _unitOfWork.HelpRepository.AddAsync(newHelp);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return newHelp.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateHelp));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Delete help
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if success</returns>
        public async Task<bool> DeleteHelp(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var help = await _unitOfWork.HelpRepository.GetAsync(h => h.Id == id);
                if (help == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                help.IsDelete = true;
                await _unitOfWork.HelpRepository.UpdateAsync(help);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteHelp));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Get all help
        /// </summary>
        /// <returns>List HelpDTO</returns>
        public async Task<List<HelpDTO>> GetAllHelp()
        {
            try
            {
                return _mapper.Map<List<HelpDTO>>(await _unitOfWork.HelpRepository
                    .GetAllAsyncNoPaging());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetAllHelp));
                throw;
            }
        }

        /// <summary>
        /// Get all help published
        /// </summary>
        /// <returns>List HelpDTO</returns>
        public async Task<List<HelpDTO>> GetAllHelpPublished()
        {
            try
            {
                return _mapper.Map<List<HelpDTO>>(await _unitOfWork.HelpRepository
                    .GetAllAsyncNoPaging(h => h.IsPublished == true));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetAllHelpPublished));
                throw;
            }
        }

        /// <summary>
        /// Get Help that match userContent by using method GetHelpByUserContent of HelpRepository
        /// </summary>
        /// <param name="userContent"></param>
        /// <returns>HelpDTO</returns>
        public async Task<HelpDetailDTO> GetHelpDetail(int id)
        {
            try
            {
                var help = await _unitOfWork.HelpRepository
                    .GetAsync(h => h.Id == id && h.IsPublished == true, h => h.HelpTopics, h => h.FAQs);
                if (help == null) 
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                return _mapper.Map<HelpDetailDTO>(help);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetHelpDetail));
                throw;
            }
        }

        /// <summary>
        /// Update help
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpEdit"></param>
        /// <returns>True if success</returns>
        public async Task<bool> UpdateHelp(int id, HelpEditDTO helpEdit)
        {
            if (id != helpEdit.Id) throw new BadRequestException(ResponseMessage.NotMatch);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var help = await _unitOfWork.HelpRepository.GetAsync(h => h.Id == id);
                if (help == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                help.UserContent = helpEdit.UserContent;
                help.IsPublished = helpEdit.IsPublished;
                await _unitOfWork.HelpRepository.UpdateAsync(help);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateHelp));
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
