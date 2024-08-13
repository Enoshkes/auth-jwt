using JwtAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Data
{
    public class UserDbContext(
        DbContextOptions<UserDbContext> options,
        IConfiguration configuration
        ): DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
