using Microsoft.EntityFrameworkCore;
using StoresAPI.Domain.Models.Base;
using System.Linq.Expressions;

namespace StoresAPI.Repository.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly StoresContext _context;
        protected readonly DbSet<T> DbSet;

        public Task<IList<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(uint id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(uint id)
        {
            throw new NotImplementedException();
        }
    }
}
