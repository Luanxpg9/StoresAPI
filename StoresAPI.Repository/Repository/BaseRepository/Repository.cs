using Microsoft.EntityFrameworkCore;
using StoresAPI.Domain.Models.Base;
using System.Linq.Expressions;

namespace StoresAPI.Repository.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly StoresContext _context;
        protected readonly DbSet<T> DbSet;

        public Repository(StoresContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        #region Create
        public async Task<T> AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        #endregion

        #region Read
        public async Task<T?> GetByIdAsync(uint id) =>
            await DbSet.FindAsync(id);

        public async Task<IList<T>> GetAllAsync(int itensPerPage, int Page) =>
             await DbSet.Skip(itensPerPage * (Page - 1)).Take(itensPerPage).ToListAsync();
        
        public async Task<IList<T>> SearchAsync(Expression<Func<T, bool>> predicate, int itensPerPage, int Page) =>
            await DbSet.AsNoTracking().Where(predicate).Skip(itensPerPage * (Page -1)).Take(itensPerPage).ToListAsync();

        public async Task<bool> AnyAsync(uint id) =>
            await DbSet.AnyAsync(e => e.Id == id);
        #endregion

        #region Update
        public async Task<T> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        #endregion

        #region Delete
        public async Task RemoveAsync(uint id)
        {
            DbSet.Remove(new T { Id = id });
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}
