using Microsoft.EntityFrameworkCore;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.Infrastructure.Data;

namespace RealTimeChat.Infrastructure.Repositories
{
    internal class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ChatContext context) : base(context)
        {
        }

        public async Task<List<Notification>> GetMyNotifications(int userId)
        {
            return await GetAll().AsNoTracking().Where(n=>n.ReceiverId == userId).ToListAsync();
        }
    }
}
