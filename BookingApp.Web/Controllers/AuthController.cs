using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.ControllerS
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
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            return response.Success ? Ok(response) : Unauthorized(response);
        }


    }

}
