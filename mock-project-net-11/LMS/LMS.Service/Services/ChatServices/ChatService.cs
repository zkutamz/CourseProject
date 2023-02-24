using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.ChatDTOs;
using LMS.Model.Response.AppUserDTOs;
using LMS.Model.Response.ChatDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using LMS.Service.Extensions;
using Microsoft.Extensions.Logging;

namespace LMS.Service.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly ILogger<ChatService> _logger;

        public ChatService(
            IUnitOfWork unitOfWork,
            IMapper mapper, 
            IUserAccessor userAccessor,
            ILogger<ChatService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _logger = logger;
        }
        public async Task<ChatDTO> AddAsync(ChatCreateDto request)
        {
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var chat = new Chat();
                await _unitOfWork.ChatRepository.AddAsync(chat);
                await _unitOfWork.SaveAsync();

                var chatUsers = new List<ChatUser>()
                {
                    new ChatUser(){ChatId = chat.Id,UserId = request.ReceiverId},
                    new ChatUser(){ChatId = chat.Id,UserId = request.CurrentUserId}
                };
                await _unitOfWork.ChatUserRepository.AddRangeAsync(chatUsers);
                await _unitOfWork.SaveAsync();
                await trans.CommitAsync();
                return _mapper.Map<ChatDTO>(chat);
            }
            catch (Exception e)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        /// <summary>
        /// Get chat, if chat is null so create new chat community
        /// </summary>
        /// <param name="get"></param>
        /// <param name="currentUserId"></param>
        /// <returns>ChatDTO</returns>
        public async Task<ChatDTO> GetAsync(ChatActionDTO get, int currentUserId)
        {
            try
            {
                var chat = await _unitOfWork.ChatRepository.GetAsync(c => c.Id == get.ChatId, c =>  c.Messages, c => c.ChatUsers );
                if(chat == null)
                {
                    return await AddAsync(new ChatCreateDto() { ReceiverId = get.UserId, CurrentUserId = currentUserId});
                }
                var user = new AppUserDTO();
                foreach(var chatUser in chat.ChatUsers)
                {
                    if (chatUser.UserId != currentUserId)
                    {
                        var tempUser = await _unitOfWork.AppUserRepository.GetAsync(u => u.Id == chatUser.UserId);
                        user = _mapper.Map<AppUserDTO>(tempUser);
                    }
                }
                var chatResult = _mapper.Map<ChatDTO>(chat);
                chatResult.Receiver = user;
                return chatResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{0} {1}", "GetAsync failed in service", nameof(GetAsync));
                throw;
            }
        }

        public Task<ChatSearchResponse> SearchChatAsync(string nameOfUser)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Block chat community from user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="block"></param>
        /// <returns>True if success</returns>
        public async Task<bool> BlockUser(int userId, ChatActionDTO block)
        {
            if (userId != block.UserId) throw new BadRequestException(ResponseMessage.NOT_MATCH);
            bool success = false;
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var chat = await _unitOfWork.ChatRepository.GetAsync(c => c.Id == block.ChatId);
                if (chat == null) 
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                if (await _unitOfWork.ChatRepository.IsOwnerChat(block.ChatId, block.UserId) && chat != null)
                {
                    chat.IsBlock = true;
                    await _unitOfWork.ChatRepository.UpdateAsync(chat);
                    await _unitOfWork.SaveAsync();
                    await trans.CommitAsync();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "BlockUser failed in service", nameof(BlockUser));
                throw;
            }
            return success;
        }

        /// <summary>
        /// Mute notification of chat community for user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mute"></param>
        /// <returns>True if success</returns>
        public async Task<bool> MuteNotificationOfChat(int userId, ChatActionDTO mute)
        {
            if(userId != mute.UserId) throw new BadRequestException(ResponseMessage.NOT_MATCH);
            bool success = false;
            await using var trans = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var chatUser = await _unitOfWork.ChatUserRepository.GetAsync(cu => cu.ChatId == mute.ChatId && cu.UserId == mute.UserId);
                if (chatUser != null)
                {
                    chatUser.IsMute = true;
                    await _unitOfWork.ChatUserRepository.UpdateAsync(chatUser);
                    await _unitOfWork.SaveAsync();
                    await trans.CommitAsync();
                    success = true;
                }
                else
                {
                    throw new NotFoundException(ResponseMessage.GetDataFailed);
                }
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                _logger.LogError(ex, "{0} {1}", "MuteNotificationOfChat failed in service", nameof(MuteNotificationOfChat));
                throw;
            }
            return success;
        }
    }
}
