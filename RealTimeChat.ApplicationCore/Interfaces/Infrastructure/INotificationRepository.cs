using RealTimeChat.ApplicationCore.Entities;

namespace RealTimeChat.ApplicationCore.Interfaces.Infrastructure
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetMyNotifications(int userId);
    }
}
