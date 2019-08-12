using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> AddMessage(Message message);
        Task CreateChat(Chat chat);
        Task<Chat> FindChat(string reciverId, string senderId);
        Task<Chat> OpenChat(string reciverId, string senderId);
        Task<Chat> GetChat(int chatId);
        Task<List<Chat>> GetChats(string userId);
    }
}
