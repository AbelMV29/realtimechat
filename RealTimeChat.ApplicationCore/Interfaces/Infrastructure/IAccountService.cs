using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.User;

namespace RealTimeChat.ApplicationCore.Interfaces.Infrastructure
{
    public interface IAccountService
    {
        Task<ServiceResponse<LoginDto>> Register(RegisterDto registerUser);
        Task<ServiceResponse<string>> Login(LoginDto loginUser);
        Task<ServiceResponse<bool>> Logout();
    }
}
