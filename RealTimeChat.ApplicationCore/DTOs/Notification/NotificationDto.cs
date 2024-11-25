using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.DTOs.Notification
{
    public class NotificationDto
    {
        public NotificationDto()
        {
            
        }
        public NotificationDto(bool seen, MessageDto message, UserDto user)
        {
            Seen = seen;
            Message = message;
            User = user;
        }

        public bool Seen { get; set; }
        public MessageDto Message { get; set; }
        public UserDto User { get; set; }
    }
}
