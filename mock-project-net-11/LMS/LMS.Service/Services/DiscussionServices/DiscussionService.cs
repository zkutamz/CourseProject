using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.DiscussionDTOs;
using LMS.Model.Request.ReactDTOs;
using LMS.Model.Response.DiscussionDTOs;
using LMS.Repository.Entities;
using LMS.Repository.Paging;
using LMS.Repository.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using LMS.Model.Response.AppUserDTOs;

namespace LMS.Service.Services.DiscussionServices
{
    public class DiscussionService : IDiscussionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DiscussionService> _logger;

        public DiscussionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DiscussionService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddAsync(int userId, DiscussionCreateDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var discussion = new Discussion()
                {
                    Content = request.Content,
                    ParentId = request.ParentId == 0 ? null : request.ParentId,
                    UserId = userId
                };
                await _unitOfWork.DiscussionRepository.AddAsync(discussion);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message);
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateAsync(int id, DiscussionEditDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                if (id != request.Id)
                {
                    throw new BadRequestException(ResponseMessage.NOT_MATCH);
                }
                var discussion = await _unitOfWork.DiscussionRepository.GetAsync(x => x.Id == request.Id);
                if (discussion == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(request.Id.ToString()));
                }

                discussion.Content = request.Content;
                discussion.ParentId = request.ParentId;
                await _unitOfWork.DiscussionRepository.UpdateAsync(discussion);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var discussion = await _unitOfWork.DiscussionRepository.GetAsync(x => x.Id == id);
                if (discussion == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(id.ToString()));
                }

                discussion.IsDelete = true;
                await _unitOfWork.DiscussionRepository.UpdateAsync(discussion);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<DiscussionDTO> GetAsync(int id)
        {
            try
            {
                var discussion = await _unitOfWork.DiscussionRepository.GetDiscussionWithReactionAsync(id);
                if (discussion == null)
                {
                    throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(id.ToString()));
                }

                var discussionDto = new DiscussionDTO()
                {
                    Content = discussion.Content,
                    ParentId = discussion.ParentId,
                    Id = discussion.Id,
                    LikeCount = discussion.Reactions.Count(c => c.Type),
                    DisLikeCount = discussion.Reactions.Count(c => !c.Type),
                    UpdatedAt = discussion.UpdatedAt,
                    User = _mapper.Map<AppUserDTO>(discussion.User),
                    ChildDiscussions = _mapper.Map<IList<DiscussionDTO>>(discussion.ChildDiscussions)
                };

                return discussionDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<DiscussionDTO>> GetAllAsync(int userId, PagingRequest pagingRequest)
        {
            try
            {
                /*var discussions = await _unitOfWork.DiscussionRepository
                    .GetAllAsync(pagingRequest, x => x.UserId == userId);*/

                var discussions = await _unitOfWork.DiscussionRepository.GetAllDiscussionAsync(userId, pagingRequest);
                var discussionDto = discussions.Select(x => new DiscussionDTO()
                {
                    Content = x.Content,
                    ParentId = x.ParentId,
                    Id = x.Id,
                    LikeCount = x.Reactions.Count(c => c.Type),
                    DisLikeCount = x.Reactions.Count(c => !c.Type),
                    UpdatedAt = x.UpdatedAt,
                    User = _mapper.Map<AppUserDTO>(x.User),
                    ChildDiscussions = x.ChildDiscussions.Select(z => new DiscussionDTO()
                    {
                        Content = z.Content,
                        ParentId = z.ParentId,
                        Id = z.Id,
                        LikeCount = z.Reactions.Count(c => c.Type),
                        DisLikeCount = z.Reactions.Count(c => !c.Type),
                        UpdatedAt = z.UpdatedAt,
                        User = _mapper.Map<AppUserDTO>(z.User),
                    }).ToList()
                }).ToList();

                return discussionDto;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<bool> ReactAsync(int currentUserId, ReactCreateDTO request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var react = await _unitOfWork.ReactRepository.GetAsync(x => x.UserId == currentUserId && x.DiscussionId == request.DiscussionId);
                if (react == null)
                {
                    await _unitOfWork.ReactRepository.AddAsync(new Reaction()
                    {
                        DiscussionId = request.DiscussionId,
                        UserId = currentUserId,
                        Type = request.Type
                    });
                }
                else if (react != null && react.Type != request.Type)
                {
                    react.Type = request.Type;
                    await _unitOfWork.ReactRepository.UpdateAsync(react);
                }
                else
                {
                    await _unitOfWork.ReactRepository.RemoveAsync(react);
                }

                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                await trans.RollbackAsync();
                throw;
            }
        }
    }
}
