using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.Message;

namespace RealTimeChat.ApplicationCore.Interfaces.Services
{
    public interface IMessageService
    {
        Task<ServiceResponse<MessageDto>> SendMessage(int actualUserId, MessageSendDto message);
        Task<ServiceResponse<bool>> SeenMessage(int actualUserId, int messageId);
        Task<ServiceResponse<ChatDto>> OpenChat(int actualUserId, int destineUserId);
        Task<ServiceResponse<List<SectionChatDto>>> GetChats(int actualUserId);
    }
}
