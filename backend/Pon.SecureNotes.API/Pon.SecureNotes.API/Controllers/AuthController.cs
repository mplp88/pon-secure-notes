using Microsoft.AspNetCore.Mvc;
using Pon.SecureNotes.Application.DTOs.Auth;
using Pon.SecureNotes.Application.Interfaces.Services;

namespace Pon.SecureNotes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = await _userService.GetByEmail(dto.Email);
            if(user is not null)
            {
                return BadRequest(new { message = "User already exists" });
            }

            var created = await _userService.Create(dto);

            return Ok(created);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userService.GetByEmail(dto.Email);
            if (user is null)
            {
                return Unauthorized(new { message = "Combinación incorrecta de usuario y contraseña" });
            }

            var valid = _authService.Verify(dto.Password, user.PasswordHash);
            if (!valid)
            {
                return Unauthorized(new { message = "Combinación incorrecta de usuario y contraseña" });
            }

            AuthResponseDto response = new()
            {
                Token = _authService.GenerateToken(user)
            };

            return Ok(response);
        }
    }
}
