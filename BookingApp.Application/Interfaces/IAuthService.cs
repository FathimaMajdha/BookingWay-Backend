using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;



namespace BookingApp.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> RegisterAsync(UserRegisterDto registerDto);
        Task<ApiResponse<JwtResponseDto>> LoginAsync(UserLoginDto loginDto);
           
    }



}


   

  

