using Microsoft.AspNetCore.Http;

namespace RealTimeChat.ApplicationCore.DTOs.Message
{
    public class MessageSendDto
    {
        public MessageSendDto()
        {

        }
        public MessageSendDto(IFormFile? mediaUrl, string body, int receiverId)
        {
            MediaUrl = mediaUrl;
            Body = body;
            ReceiverId = receiverId;
        }

        public IFormFile? MediaUrl { get; set; }
        public string Body { get; set; }
        public int ReceiverId { get; set; }
    }
}
