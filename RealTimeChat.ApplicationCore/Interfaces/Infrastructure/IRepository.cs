using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.ApplicationCore.Interfaces.Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(int id);
        void Edit(T entity);
        Task<T> AddAsync(T entity);
        void Delete(int id);
        Task SaveChangesAsync();
    }
}
