using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.DTOs.Notification;

namespace RealTimeChat.ApplicationCore.Interfaces.Services
{
    public interface INotificationService
    {
        Task<ServiceResponse<NotificationDto>> SendNotification(int actualUserId, MessageDto message);
        Task<ServiceResponse<bool>> SeenNotification(int actualUserId, int notificationId);
        Task<ServiceResponse<List<NotificationDto>>> GetAllNotifications(int actualUserId);
    }
}
