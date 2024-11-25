using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.Message;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Services;
using System.Security.Claims;

namespace RealTimeChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost("")]
        public async Task<ActionResult<ServiceResponse<MessageDto>>> SendMessage(MessageSendDto message)
        {
            int actualUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var serviceResponse = await _messageService.SendMessage(actualUserId, message);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpPut("seen/{messageId}")]
        public async Task<ActionResult<ServiceResponse<MessageDto>>> SeenMessage(int messageId)
        {
            int actualUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var serviceResponse = await _messageService.SeenMessage(actualUserId, messageId);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [Authorize]
        [HttpGet("chats")]
        public async Task<ActionResult<ServiceResponse<List<SectionChatDto>>>> GetChats()
        {
            var xd =HttpContext;
            int actualUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var serviceResponse = await _messageService.GetChats(actualUserId);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [Authorize]
        [HttpGet("chat/{destineUserId}")]
        public async Task<ActionResult<ServiceResponse<ChatDto>>> OpenChat(int destineUserId)
        {
            int actualUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var serviceResponse = await _messageService.OpenChat(actualUserId, destineUserId);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
