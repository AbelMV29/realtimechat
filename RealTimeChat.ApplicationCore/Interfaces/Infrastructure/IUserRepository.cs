using RealTimeChat.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.Interfaces.Infrastructure
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<List<User>> GetAllUserWithUserNameAsync(string? userName, int count);
    }
}
