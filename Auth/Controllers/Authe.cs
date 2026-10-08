using Auth.Model;
using Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authe : ControllerBase
    {
        private readonly IAuthService _service;

        public Authe(IAuthService authService)
        {
            this._service=authService;
            
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register register )
        {
            var result = await _service.RegisterAsync(register);
            if (result.IsSuccess)
            {
              return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var result = await _service.LoginAsync(login);
            if (result.IsSuccess) return Ok(result);
            return Unauthorized(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return Ok(new { message = "Logout Successful" });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return Ok("Admin Only Endpoint");
        }

        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public IActionResult User()
        {
            return Ok("User Only Endpoint");
        }

    }
}
