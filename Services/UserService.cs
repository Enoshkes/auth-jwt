using JwtAuthentication.Data;
using JwtAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.Services
{
    public class UserService(UserDbContext userDbContext) : IUserService
    {
        public async Task<UserDetails?> FindByEmailAndPasswordAsync(string email, string password) =>
            await userDbContext.UserDetails.FirstOrDefaultAsync(user => 
                user.Email == email && 
                user.Password == password
            );

        public async Task<UserDetails?> FindUserByIdAsync(int id) =>
            await userDbContext.UserDetails.FindAsync(id);

        public async Task<List<UserDetails>> GetAllUsersAsync() =>
            await userDbContext.UserDetails.ToListAsync();

        public async Task<UserDetails> SaveUserAsync(UserDetails userDetails)
        {
            await userDbContext.UserDetails.AddAsync(userDetails);
            await userDbContext.SaveChangesAsync();
            return userDetails;
        }
    }
}
