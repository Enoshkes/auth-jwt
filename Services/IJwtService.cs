using JwtAuthentication.Models;

namespace JwtAuthentication.Services
{
    public interface IJwtService
    {
        string GenerateToken(UserDetails user);
    }
}
