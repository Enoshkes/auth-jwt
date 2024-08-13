using JwtAuthentication.Dto;
using JwtAuthentication.Models;
using JwtAuthentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService, IJwtService jwtService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await userService.FindByEmailAndPasswordAsync(
                loginDto.Email, 
                loginDto.Password
            );

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var token = jwtService.GenerateToken(user);
            return Ok(new { token });
        }

    }
}
