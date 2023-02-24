using LMS.Repository.Context;
using LMS.Repository.Entities;
using LMS.Repository.Interfaces;
using LMS.Repository.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LMS.Repository.Repositories
{
    public class ChatUserRepository : Repository<ChatUser>, IChatUserRepository
    {
        public ChatUserRepository(LMSApplicationContext context, ILogger<ChatUserRepository> logger, IOptionsSnapshot<ResponseMessageOptions> responseMessage) : base(context, logger, responseMessage)
        {

        }
    }
}
