using System;
using System.Collections.Generic;
using System.Text;
using LMS.Repository.Entities;
using System.Threading.Tasks;

namespace LMS.Repository.Interfaces
{
    public interface IChatRepository : IRepository<Chat>
    {
        Task<Chat> GetChatById(int id);
        Task<bool> IsOwnerChat(int chatId, int userId);
    }
}
