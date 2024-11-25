using RealTimeChat.ApplicationCore.DTOs.User;

namespace RealTimeChat.ApplicationCore.DTOs.Message
{
    public class SectionChatDto
    {
        public SectionChatDto()
        {

        }
        public SectionChatDto(MessageDto lastMessage, UserDto user)
        {
            LastMessage = lastMessage;
            User = user;
        }

        public MessageDto LastMessage { get; set; }
        public UserDto User { get; set; }
    }
}
