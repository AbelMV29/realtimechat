using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.DTOs.User;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.Infrastructure.Data;

namespace RealTimeChat.Infrastructure.Repositories
{
    internal class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly IUserRepository _userRepository;

        public MessageRepository(ChatContext context, IUserRepository userRepository) : base(context)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Message>> GetChat(int userId, int destineId)
        {
            return await GetAll().AsNoTracking().Where(m => (m.SenderId == userId && m.ReceiverId == destineId) || (m.SenderId == destineId && m.ReceiverId == userId)).OrderBy(m => m.Date).ToListAsync();
        }

        public async Task<List<Message>> GetChatsByUser(int userId)
        {
            var ids = await _userRepository.GetAll().Where(u => u.Id != userId).Select(u=>u.Id).ToListAsync();

            List<Message> messages = new List<Message>();

            foreach (var id in ids)
            {
                Message? message = await GetAll().Include(m=>m.Receiver).Include(m=>m.Sender).Where(m => (m.SenderId == userId && m.ReceiverId == id) ||
                                                    (m.SenderId == id && m.ReceiverId == userId))
                                        .OrderByDescending(m => m.Date)
                                        .Take(1).FirstOrDefaultAsync();
                if(message is null)
                {
                    continue;
                }
                messages.Add(message);
            }
            return messages;
        }
    }
}
