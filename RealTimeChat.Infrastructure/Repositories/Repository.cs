using Microsoft.EntityFrameworkCore;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using RealTimeChat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChat.Infrastructure.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected ChatContext _context;
        public Repository(ChatContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity is null) throw new Exception("Entidad no encontrada");
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Update(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
