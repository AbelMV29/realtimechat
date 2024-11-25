using Microsoft.AspNetCore.SignalR;
using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.DTOs.User;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Hub;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.ApplicationCore.Interfaces.Services;

namespace RealTimeChat.ApplicationCore.Services
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly INotificationService _notificationService;
        private readonly IHubContext<ChatHub, IChatHub> _hubContext;
        private readonly IUserRepository _userRepository;

        public MessageService(IMessageRepository messageRepository, INotificationService notificationService,
            IHubContext<ChatHub, IChatHub> hubContext, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _notificationService = notificationService;
            _hubContext = hubContext;
            _userRepository = userRepository;
        }
        public async Task<ServiceResponse<List<SectionChatDto>>> GetChats(int actualUserId)
        {
            var chats = await _messageRepository.GetChatsByUser(actualUserId);
            List<SectionChatDto> sectionChatDtos = chats.Select(m =>
            {
                MessageDto lastMessage = new MessageDto(m.Id, m.MediaUrl, m.Body, m.Seen, m.Date, m.SenderId);
                UserDto userSectionChat;
                if (actualUserId == m.ReceiverId)
                {
                    userSectionChat = new UserDto(m.Sender.Id, m.Sender.PhotoUrl, string.Concat(m.Sender.Name, " ", m.Sender.LastName), m.Sender.UserName);

                }
                else
                {
                    userSectionChat = new UserDto(m.Receiver.Id, m.Receiver.PhotoUrl, string.Concat(m.Receiver.Name, " ", m.Receiver.LastName), m.Receiver.UserName);

                }

                return new SectionChatDto(lastMessage, userSectionChat);
            }).ToList();

            return new ServiceResponse<List<SectionChatDto>>(true, sectionChatDtos, null);
        }

        public async Task<ServiceResponse<ChatDto>> OpenChat(int actualUserId, int destineUserId)
        {
            var userDestine = await _userRepository.GetByIdAsync(destineUserId);
            if (userDestine is null)
                return new ServiceResponse<ChatDto>(false, null, $"El usuario destino con id {destineUserId} no existe.");
            var messages = await _messageRepository.GetChat(actualUserId, destineUserId);
            ChatDto chatDto = new ChatDto(
                messages.Select(m => new MessageDto(m.Id, m.MediaUrl, m.Body, m.Seen, m.Date, m.SenderId)).ToList(),
                new UserDto(userDestine.Id, userDestine.PhotoUrl, string.Concat(userDestine.Name, " ", userDestine.LastName), userDestine.UserName),
                false);
            return new ServiceResponse<ChatDto>(true, chatDto, null);
        }

        public async Task<ServiceResponse<bool>> SeenMessage(int actualUserId, int messageId)
        {
            var messageToView = await _messageRepository.GetByIdAsync(messageId);
            if (messageToView is null)
                return new ServiceResponse<bool>(false, false, $"No existe un mensaje con el id {messageId}");

            messageToView.Seen = true;
            try
            {
                _messageRepository.Edit(messageToView);
                await _messageRepository.SaveChangesAsync();
                //Invoke signalR Clients method ReceiveSeen
                return new ServiceResponse<bool>(true, true, null);
            }
            catch(Exception ex)
            {
                return new ServiceResponse<bool>(false, false, ex.Message);
            }
        }

        public async Task<ServiceResponse<MessageDto>> SendMessage(int actualUserId, MessageSendDto message)
        {
            var receiver = await _userRepository.GetByIdAsync(message.ReceiverId);
            if (receiver is null)
                return new ServiceResponse<MessageDto>(false, null, "El usuario destino no existe.");
            Message messageToAdd = new Message();
            messageToAdd.SenderId = actualUserId;
            messageToAdd.ReceiverId = message.ReceiverId;
            messageToAdd.Body = message.Body;
            messageToAdd.Date = DateTime.UtcNow.AddHours(-3);
            messageToAdd.Seen = false;
            try
            {
                var messageResult = await _messageRepository.AddAsync(messageToAdd);
                await _messageRepository.SaveChangesAsync();
                
                MessageDto messageDto = new MessageDto(messageResult.Id, messageResult.MediaUrl, messageResult.Body, messageResult.Seen, messageResult.Date, messageResult.SenderId);
                //Invoke signalR Clients method ReceiveMessage
                return new ServiceResponse<MessageDto>(true, messageDto, null);
            }
            catch(Exception ex)
            {
                return new ServiceResponse<MessageDto>(false, null, ex.Message);
            }
            
        }
    }
}
