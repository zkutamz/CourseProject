using LMS.Model.Constant;
using LMS.Model.Request.ChatDTOs;
using LMS.Service.Services.ChatServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateNewChatCommunicate(ChatCreateDto chatCreate)
        {
            return HandleResult(await _chatService.AddAsync(chatCreate), LmsAction.Add);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetChatCommunicate(ChatActionDTO get, int currentUserId)
        {
            return HandleResult(await _chatService.GetAsync(get, currentUserId), LmsAction.Get);
        }

        [HttpPut]
        [Route("block")]
        public async Task<IActionResult> BlockUser(int userId, ChatActionDTO block)
        {
            return HandleResult(await _chatService.BlockUser(userId, block), LmsAction.Update);
        }

        [HttpPut]
        [Route("mute-notification")]
        public async Task<IActionResult> MuteNotificationOfChat(int userId, ChatActionDTO mute)
        {
            return HandleResult(await _chatService.MuteNotificationOfChat(userId, mute), LmsAction.Update);
        }
    }
}
