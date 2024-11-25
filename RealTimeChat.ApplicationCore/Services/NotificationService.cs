using Microsoft.AspNetCore.SignalR;
using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.DTOs.Notification;
using RealTimeChat.ApplicationCore.DTOs.User;
using RealTimeChat.ApplicationCore.Hub;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.ApplicationCore.Interfaces.Services;

namespace RealTimeChat.ApplicationCore.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IHubContext<ChatHub, IChatHub> _hubContext;
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;

        public NotificationService(INotificationRepository notificationRepository, IHubContext<ChatHub, IChatHub> hubContext,
            IUserRepository userRepository, IMessageRepository messageRepository)
        {
            _notificationRepository = notificationRepository;
            _hubContext = hubContext;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }
        public async Task<ServiceResponse<List<NotificationDto>>> GetAllNotifications(int actualUserId)
        {
            var notifications = await _notificationRepository.GetMyNotifications(actualUserId);
            List<NotificationDto> notificationsDto = new List<NotificationDto>();
            foreach (var notification in notifications)
            {
                var message = await _messageRepository.GetByIdAsync(notification.MessageId);
                MessageDto messageDto = new MessageDto(message.Id, message.MediaUrl, message.Body, message.Seen, message.Date, message.SenderId);
                var user = await _userRepository.GetByIdAsync(message.SenderId);
                UserDto userDto = new UserDto(user.Id, user.PhotoUrl, string.Concat(user.Name, " ", user.LastName), user.UserName);
                NotificationDto notificationDto = new NotificationDto(false, messageDto, userDto);
            }
            return new ServiceResponse<List<NotificationDto>>(true, notificationsDto, null);
        }

        public Task<ServiceResponse<bool>> SeenNotification(int actualUserId, int notificationId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<NotificationDto>> SendNotification(int actualUserId, MessageDto message)
        {
            throw new NotImplementedException();
        }
    }
}
