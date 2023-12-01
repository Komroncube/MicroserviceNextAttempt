using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using NajotNur.Domain.Models;
using NajotNur.Infrastructure.Services;

namespace NajotNur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);  
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateUser(User user)
        {
            try
            {
                await _userService.CreateUserAsync(user);
                return Created(Request.GetDisplayUrl(), user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
