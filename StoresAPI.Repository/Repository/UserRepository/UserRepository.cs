using Microsoft.EntityFrameworkCore;
using StoresAPI.Domain.Models;
using StoresAPI.Repository.BaseRepository;
using System.Linq.Expressions;

namespace StoresAPI.Repository.Repository.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(StoresContext context) : base(context) { }

        public async Task<bool> AnyAsync(Expression<Func<User, bool>> predicate) => 
            await DbSet.AnyAsync(predicate);

        public async Task<User?> GetByCPF(string CPF) => 
            await DbSet.FirstOrDefaultAsync(u => u.CPF.Equals(CPF));

        public async Task<User?> GetByUsername(string username) =>
            await DbSet.FirstOrDefaultAsync(u => u.Username.Equals(username));
    }
}
