using RealTimeChat.ApplicationCore.Entities;

namespace RealTimeChat.ApplicationCore.Interfaces.Infrastructure
{
    public interface IMessageRepository : IRepository<Message>
    {
        Task<List<Message>> GetChatsByUser(int userId);
        Task<List<Message>> GetChat(int userId, int destineId);
    }
}
