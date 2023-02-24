using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.HelpArticleDTOs;
using LMS.Model.Response.HelpArticleDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Service.Services.HelpArticleServices
{
    public class HelpArticleService : IHelpArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HelpArticleService> _logger;
        private readonly IMapper _mapper;

        public HelpArticleService(IUnitOfWork unitOfWork, ILogger<HelpArticleService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Create Article
        /// </summary>
        /// <param name="helpArticle"></param>
        /// <returns>HelpArticleDTO</returns>
        public async Task<HelpArticleDTO> CreateHelpArticle(HelpArticleCreateDTO helpArticleDTO)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var helpArticle = _mapper.Map<HelpArticle>(helpArticleDTO);
                await _unitOfWork.HelpArticleRepository.AddAsync(helpArticle);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if (!isSave) throw new Exception(ResponseMessage.AddFailure);
                await transaction.CommitAsync();
                _logger.LogInformation("Create FAQ Success");
                return _mapper.Map<HelpArticleDTO>(helpArticle);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        /// <summary>
        /// Delete Article By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true-false</returns>
        public async Task<bool> DeleteHelpArticle(int id)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var helpArticle = await _unitOfWork.HelpArticleRepository.GetAsync(x => x.Id == id);
                if (helpArticle == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(id.ToString()));
                await _unitOfWork.HelpArticleRepository.RemoveAsync(helpArticle);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if(!isSave) throw new Exception(ResponseMessage.DeleteFailure);
                _logger.LogInformation(ResponseMessage.DeleteSuccess);
                await transaction.CommitAsync();
                return isSave;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Get All Article By Topic
        /// </summary>
        /// <param name="helpTopicId"></param>
        /// <param name="pagingRequest"></param>
        /// <returns>List HelpActicleDTO</returns>
        public async Task<PagingResult<HelpArticleDTO>> GetAllArticle(int helpTopicId, PagingRequest pagingRequest)
        {
            var helpArticles = await _unitOfWork.HelpArticleRepository
                .GetAllAsync(pagingRequest, x => x.HelpTopicId == helpTopicId);
            if (helpArticles == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(helpTopicId.ToString()));
            var paginatedListArticle = _mapper.Map<PaginatedList<HelpArticleDTO>>(helpArticles);
            return new PagingResult<HelpArticleDTO>
            {
                PageSize = paginatedListArticle.PageSize,
                CurrentPage = paginatedListArticle.CurrentPage,
                TotalPages = paginatedListArticle.TotalPages,
                TotalCount = paginatedListArticle.TotalCount,
                Objects = paginatedListArticle
            };
        }
        /// <summary>
        ///  Get All Article By Topic
        /// </summary>
        /// <param name="helpTopicId">int helpTopicID</param>
        /// <returns>List<HelpArticleDTO></returns>
        public List<HelpArticleDTO> GetAllArticle(int helpTopicID)
        {
            try
            {
                return _mapper.Map<List<HelpArticleDTO>>( _unitOfWork.HelpArticleRepository.GetAllArticle(helpTopicID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get All Article failed in service",
                    nameof(GetAllArticle));
                throw;
            }
        }

        /// <summary>
        /// Get Detail Article
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HelpArticleDetailDTO</returns>
        public async Task<HelpArticleDetailDTO> GetArticleDetail(int id)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                return _mapper.Map<HelpArticleDetailDTO>(await _unitOfWork.HelpArticleRepository.GetAsync(ha => ha.Id == id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "Get Article Detail failed in service",
                    nameof(GetArticleDetail));
                await transaction.RollbackAsync();
                throw;
            }
        }
        /// <summary>
        /// Update HelpArticle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helpArticle"></param>
        /// <returns>true-false</returns>
        public async Task<bool> UpdateHelpArticle(int id, HelpArticleEditDTO helpArticleDTO)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var helpArticle = await _unitOfWork.HelpArticleRepository.GetAsync(x => x.Id == id);
                if (helpArticle == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(id.ToString()));
                helpArticle.Title = helpArticleDTO.Title;
                helpArticle.Content = helpArticleDTO.Content;
                helpArticle.HelpTopicId = helpArticleDTO.HelpTopicId;
                await _unitOfWork.HelpArticleRepository.UpdateAsync(helpArticle);
                var isSave = await _unitOfWork.SaveAsync() > 0;
                if (!isSave) throw new Exception(ResponseMessage.UpdateFailure);
                _logger.LogInformation(ResponseMessage.UpdateSuccess);
                await transaction.CommitAsync();
                return isSave;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<PagingResult<HelpArticleDTO>> GetHelpSearch(string keyword, PagingRequest pagingRequest)
        {
            var helpArticles = await _unitOfWork.HelpArticleRepository
                .GetAllAsync(pagingRequest, x => x.Title.Contains(keyword));
            if (helpArticles == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(keyword));
            var paginatedListArticle = _mapper.Map<PaginatedList<HelpArticleDTO>>(helpArticles);
            return new PagingResult<HelpArticleDTO>
            {
                PageSize = paginatedListArticle.PageSize,
                CurrentPage = paginatedListArticle.CurrentPage,
                TotalPages = paginatedListArticle.TotalPages,
                TotalCount = paginatedListArticle.TotalCount,
                Objects = paginatedListArticle
            };
        }
    }
}
