using Microsoft.AspNetCore.Mvc;
using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.Notification;
using RealTimeChat.ApplicationCore.Interfaces.Services;
using System.Security.Claims;

namespace RealTimeChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpPost("seen/{notificationId}")]
        public async Task<ActionResult<ServiceResponse<NotificationDto>>> SeenNotification(int notificationId)
        {
            int actualUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var serviceResponse = await _notificationService.SeenNotification(actualUserId, notificationId);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<NotificationDto>>> GetAllNotifications()
        {
            int actualUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var serviceResponse = await _notificationService.GetAllNotifications(actualUserId);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
