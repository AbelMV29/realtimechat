using RealTimeChat.ApplicationCore.DTOs.User;

namespace RealTimeChat.ApplicationCore.DTOs.Message
{
    public class ChatDto
    {
        public ChatDto()
        {
            
        }
        public ChatDto(List<MessageDto> messages, UserDto user, bool inChat)
        {
            Messages = messages;
            User = user;
            InChat = inChat;
        }

        public List<MessageDto> Messages { get; set; }
        public UserDto User { get; set; }
        public bool InChat { get; set; }
    }
}
