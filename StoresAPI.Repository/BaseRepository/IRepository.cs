using System.Linq.Expressions;

namespace StoresAPI.Repository.BaseRepository
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(uint id);
        Task<IList<T>> SearchAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> SearchAsync(Expression<Func<T, bool>> predicate, int itensPerPage, int Page);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(int itensPerPage, int Page);
        Task<bool> AnyAsync(uint id);
        Task<T> UpdateAsync(T entity);
        void SoftRemoveAsync(uint id);
        Task RemoveAsync(uint id);
    }
}
