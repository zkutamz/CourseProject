using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.HelpTopicDTOs;
using LMS.Model.Response.HelpTopicDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LMS.Service.Services.HelpTopicServices
{
    public class HelpTopicService : IHelpTopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HelpTopicService> _logger;
        private readonly IMapper _mapper;

        public HelpTopicService(IUnitOfWork unitOfWork, ILogger<HelpTopicService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Create new help topic
        /// </summary>
        /// <param name="helpTopicCreate"></param>
        /// <returns>New helpTopicId</returns>
        public async Task<int> CreateHelpTopic(HelpTopicCreateDTO helpTopicCreate)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var newHelpTopic = _mapper.Map<HelpTopic>(helpTopicCreate);
                await _unitOfWork.HelpTopicRepository.AddAsync(newHelpTopic);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return newHelpTopic.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(CreateHelpTopic));
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteHelpTopic(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var helpTopic = await _unitOfWork.HelpTopicRepository.GetAsync(ht => ht.Id == id);
                if (helpTopic == null) 
                   throw new NotFoundException(ResponseMessage.GetDataFailed);
                helpTopic.IsDelete = true;
                await _unitOfWork.HelpTopicRepository.UpdateAsync(helpTopic);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(DeleteHelpTopic));
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Get topic detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HelpTopicDetailDTO</returns>
        public async Task<HelpTopicDetailDTO> GetTopicDetail(int id)
        {
            try
            {
                var helpTopic = await _unitOfWork.HelpTopicRepository.GetAsync(ht => ht.Id == id && ht.IsDelete == false, ht => ht.HelpArticles);
                if (helpTopic == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                return _mapper.Map<HelpTopicDetailDTO>(helpTopic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetTopicDetail));
                throw;
            }
        }


        public async Task<bool> UpdateHelpTopic(int id, HelpTopicEditDTO helpTopicEdit)
        {
            if (id != helpTopicEdit.Id) throw new BadRequestException(ResponseMessage.NotMatch);
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var helpTopic = await _unitOfWork.HelpTopicRepository.GetAsync(ht => ht.Id == id);
                if (helpTopic == null)
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                helpTopic.Title = helpTopicEdit.Title;
                helpTopic.IconURL = helpTopicEdit.IconURL;
                helpTopic.Description = helpTopicEdit.Description;
                helpTopic.HelpId = helpTopicEdit.HelpId;
                await _unitOfWork.HelpTopicRepository.UpdateAsync(helpTopic);
                await _unitOfWork.SaveAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(UpdateHelpTopic));
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
