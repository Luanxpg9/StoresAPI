using System.Linq.Expressions;

namespace StoresAPI.Repository.BaseRepository
{
    public interface IRepository<T>
    {
        Task<IList<T>> SearchAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(uint id);
        Task<IList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Remove(uint id);
        Task<bool> AnyAsync(uint id);
    }
}
