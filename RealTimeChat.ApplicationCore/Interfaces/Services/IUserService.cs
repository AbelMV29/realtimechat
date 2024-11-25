using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserDto>>> GetUsers(string? userName = null);
        Task<ServiceResponse<UserDto>> GetUser(string userName);
    }
}
