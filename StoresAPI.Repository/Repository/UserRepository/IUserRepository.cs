using StoresAPI.Domain.Models;
using StoresAPI.Repository.BaseRepository;
using System.Linq.Expressions;

namespace StoresAPI.Repository.Repository.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> AnyAsync(Expression<Func<User, bool>> predicate);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByCPF(string CPF);
    }
}
