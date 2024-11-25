using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.User;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ServiceResponse<UserDto>> GetUser(string userName)
        {
            var user = await _userRepository.GetByUserNameAsync(userName);
            if (user is null)
                return new ServiceResponse<UserDto>(false, null, $"No existe un perfil con el nombre de usuario '{userName}'");

            UserDto userDto = new UserDto(user.Id, user.PhotoUrl, string.Concat(user.Name, " ", user.LastName), userName);
            return new ServiceResponse<UserDto>(true, userDto, null);
        }

        public async Task<ServiceResponse<List<UserDto>>> GetUsers(string? userName = null)
        {
            var users = await _userRepository.GetAllUserWithUserNameAsync(userName, 10);
            var listUserDto = users.Select(u => new UserDto(u.Id, u.PhotoUrl, string.Concat(u.Name, " ", u.LastName), u.UserName)).ToList();
            return new ServiceResponse<List<UserDto>>(true, listUserDto, null);
        }
    }
}
