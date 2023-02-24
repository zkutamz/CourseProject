using LMS.Model.Request.ChatDTOs;
using LMS.Model.Response.ChatDTOs;
using System.Threading.Tasks;

namespace LMS.Service.Services.ChatServices
{
    public interface IChatService
    {
        Task<ChatDTO> AddAsync(ChatCreateDto request);
        /// <summary>
        /// Get chat, if chat is null so create new chat community
        /// </summary>
        /// <param name="get"></param>
        /// <param name="currentUserId"></param>
        /// <returns>ChatDTO</returns>
        Task<ChatDTO> GetAsync(ChatActionDTO get, int currentUserId);

        /// <summary>
        /// Block chat community from user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="block"></param>
        /// <returns>True if success</returns>
        Task<bool> BlockUser(int userId, ChatActionDTO block);

        Task<ChatSearchResponse> SearchChatAsync(string nameOfUser);

        /// <summary>
        /// Mute notification of chat community for user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mute"></param>
        /// <returns>True if success</returns>
        Task<bool> MuteNotificationOfChat(int userId, ChatActionDTO mute);
    }
}
