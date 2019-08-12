using ServerCode.Model.Database;
using ServerCode.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ServerCode.Model.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserRepository _userRepository;


        public MessageRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Message> AddMessage(Message message)
        {
            await _databaseContext.Messages.AddAsync(message);
            await _databaseContext.SaveChangesAsync();
            return message;
        }
        public async Task CreateChat(Chat chat)
        {
            await _databaseContext.Chats.AddAsync(chat);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<Chat> FindChat(string reciverId, string senderId)
        {

            return await _databaseContext.Chats
                .Where(c => c.OwnerId == senderId)
                .Where(c => c.ReciverId == reciverId)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync();
        }
        public async Task<Chat> OpenChat(string reciverId, string senderId)
        {
            var chat = await FindChat(reciverId, senderId);
            if (chat == null)
            {
                
                Chat chatCreated = new Chat()
                {
                    OwnerId = senderId,
                    ReciverId = reciverId
                };

                await CreateChat(chatCreated);
                return chatCreated;
            }
            else
            {
                return chat;
            }

        }
        public async Task<Chat> GetChat(int chatId)
        {
            return await _databaseContext.Chats
                .Include(c => c.Reciver)
                .Include(c => c.Owner)
                .Include(c => c.Messages)
                .FirstAsync(c => c.Id == chatId);
        }
        public async Task<List<Chat>> GetChats(string userId)
        {
            return await _databaseContext.Chats
                .Include(c => c.Reciver)
                .Include(c => c.Owner)
                .Include(c => c.Messages)
                .Where(c => c.Owner.Id == userId || c.Reciver.Id == userId)

                .ToListAsync();
        }
    }
}
