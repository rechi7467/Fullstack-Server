using Fullstack.Core.Models.DTOs;
using Fullstack.Core.Models.DTOs.Fullstack.Core.Models.DTOs;
using Fullstack.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fullstack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            try
            {
                var user = await _authService.RegisterAsync(model);
                return Ok(new { message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            try
            {
                var token = await _authService.LoginAsync(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}