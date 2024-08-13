using JwtAuthentication.Models;

namespace JwtAuthentication.Services
{
    public interface IUserService
    {
        Task<UserDetails?> FindByEmailAndPasswordAsync(string email, string password);

        Task<UserDetails> SaveUserAsync(UserDetails userDetails);

        Task<List<UserDetails>> GetAllUsersAsync();

        Task<UserDetails?> FindUserByIdAsync(int id);
    }
}
