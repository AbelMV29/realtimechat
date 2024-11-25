using Microsoft.AspNetCore.SignalR;
using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.Hub
{
    public interface IChatHub
    {
        Task ReceiveMessage(MessageDto message);
        Task ReceiveNotification(NotificationDto notification);
    }
    public class ChatHub: Microsoft.AspNetCore.SignalR.Hub<IChatHub>
    {
        public async Task SendMessage(MessageDto message, int receiverId)
        {
        }
        public async Task NotificateMessage(NotificationDto notification, int receiverId)
        {

        }
        public async Task ShowState(int receiverId, bool inChat)
        {

        }
    }
}
