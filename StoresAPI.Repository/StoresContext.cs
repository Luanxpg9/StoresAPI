using Microsoft.EntityFrameworkCore;
using StoresAPI.Domain.Models;

namespace StoresAPI.Repository
{
    public class StoresContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }

        //Relations
        public DbSet<UserStore> UserStore { get; set; }

        public StoresContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // TODO: Test connection using docker
                // Make sure to add your Connection string to the Enviroment Variables
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("LOCAL_SQL")!);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Setting unique fields
            builder.Entity<User>(u =>
            {
                u.HasIndex(u => u.Username).IsUnique();
                u.HasIndex(u => u.CPF).IsUnique();
            });

            builder.Entity<Store>(s =>
            {
                s.HasIndex(s => s.Name).IsUnique();
                s.HasIndex(s => s.CNPJ).IsUnique();
            });

            #region Relationships
            builder.Entity<UserStore>(us =>
            {
                // Limit the role length to 127 roles || if you use negative values the range is (-128 -> 127) total 255 roles
                us.Property(us => us.Role).HasColumnType("tinyint");
            });

            #endregion

        }
    }
    
}
