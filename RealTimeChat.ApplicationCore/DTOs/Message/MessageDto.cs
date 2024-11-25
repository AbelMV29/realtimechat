using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.DTOs.Message
{
    public class MessageDto
    {
        public MessageDto()
        {
            
        }
        public MessageDto(int id, string? mediaUrl, string body, bool seen, DateTime date, int senderId)
        {
            Id = id;
            MediaUrl = mediaUrl;
            Body = body;
            Seen = seen;
            Date = date;
            SenderId = senderId;
        }

        public int Id { get; set; }
        public string? MediaUrl { get; set; }
        public string Body { get; set;   }
        public bool Seen { get; set; }
        public DateTime Date { get; set; }
        public int SenderId { get; set; }
    }
}
