using JwtAuthentication.Models;
using JwtAuthentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDetails>>> GetAllUsers() =>
            await userService.GetAllUsersAsync();


        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetails>> CreateUser([FromBody] UserDetails user)
        {
            var savedUser = await userService.SaveUserAsync(user);
            return Ok(savedUser);
        }
    }
}
