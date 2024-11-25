using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.Infrastructure.Data;

namespace RealTimeChat.Infrastructure.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ChatContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllUserWithUserNameAsync(string? userName, int count)
        {
            if(!userName.IsNullOrEmpty()) 
            {
                return await GetAll()
                    .AsNoTracking()
                    .Where(u => u.UserName
                        .ToLower()
                        .Contains(userName.ToLower()))
                    .Take(count)
                    .ToListAsync();
            }
            return await GetAll()
                .AsNoTracking()
                .Take(count)
                .ToListAsync();
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await GetAll().AsNoTracking().FirstOrDefaultAsync(u => u.UserName == userName);
        }

    }
}
