using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepo, IJwtService jwtService)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<string>> RegisterAsync(UserRegisterDto registerDto)
        {
            try
            {
                var user = new UserAuth
                {
                    Username = registerDto.Username,
                    Email = registerDto.Email,
                    Password = registerDto.Password,
                    Role = "User"
                };

                var registeredUser = await _userRepo.RegisterUserAsync(user);

                if (registeredUser == null)
                    return ApiResponse<string>.FailResponse("User already exists.");

                return ApiResponse<string>.SuccessResponse("User registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterAsync: {ex.Message}");
                return ApiResponse<string>.FailResponse("Internal server error.");
            }
        }

        public async Task<ApiResponse<JwtResponseDto>> LoginAsync(UserLoginDto loginDto)
        {
            try
            {
                var user = await _userRepo.GetByLoginAsync(loginDto.Username, loginDto.Password);

                if (user == null)
                    return ApiResponse<JwtResponseDto>.FailResponse("Invalid credentials.");

               
                if (user.IsBlocked)
                    return ApiResponse<JwtResponseDto>.FailResponse("Your account has been blocked. Please contact administrator.");

                var token = _jwtService.GenerateToken(user);

                var jwtResponse = new JwtResponseDto
                {
                    Token = token,
                    Username = user.Username,
                    Role = user.Role,
                    UserAuthId = user.UserAuthId,
                    IsBlocked = user.IsBlocked
                };

                return ApiResponse<JwtResponseDto>.SuccessResponse(jwtResponse, "Login successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoginAsync: {ex.Message}");
                return ApiResponse<JwtResponseDto>.FailResponse("Internal server error.");
            }
        }
    }
}