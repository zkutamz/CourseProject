using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using LMS.Repository.Options;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class ChatRepository : Repository<Chat>, IChatRepository
    {
        public ChatRepository(LMSApplicationContext context, ILogger<ChatRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {

        }

        public async Task<Chat> GetChatById(int id)
        {
            try
            {
                return await Context.Chats.Include(c => c.ChatUsers).Include(c => c.Messages).FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(GetChatById));
                throw;
            }
        }

        public async Task<bool> IsOwnerChat(int chatId, int userId)
        {
            try
            {
                return await Context.Chats.Where(c => c.Id == chatId).AnyAsync(c => c.ChatUsers.Any(cu => cu.UserId == userId));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} {1}", "Something went wrong in ", nameof(IsOwnerChat));
                throw;
            }
        }
    }
}
