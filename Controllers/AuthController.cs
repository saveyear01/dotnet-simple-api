using Microsoft.AspNetCore.Mvc;
using AuthApi.Models;
using AuthApi.Services;
using AuthApi.Models.DTOs;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/auth/register
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var response = _userService.Register(request);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        // POST: api/auth/login
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = _userService.Login(request);
            if (!response.Success)
                return Unauthorized(response);

            return Ok(response);
        }
    }
}
