using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.User;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.ApplicationCore.Interfaces.Services;
using System.Security.Claims;

namespace RealTimeChat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UsersController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<LoginDto>>> Register(RegisterDto registerUser)
        {
            var serviceResponse = await _accountService.Register(registerUser); 
            if(!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return StatusCode(StatusCodes.Status201Created,serviceResponse);
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginDto loginUser)
        {
            var serviceResponse = await _accountService.Login(loginUser);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<ActionResult<ServiceResponse<bool>>> Logout()
        {
            var serviceResponse = await _accountService.Logout();
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpGet("")]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> GetUsers([FromQuery]string? userName = null)
        {
            var serviceResponse = await _userService.GetUsers(userName);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
        [HttpGet("{userName}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetUser(string userName)
        {
            var serviceResponse = await _userService.GetUser(userName);
            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }
            return Ok(serviceResponse);
        }
    }
}
