using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<ApiResponse<int>> AddUserAsync(UserProfileDto user, int userAuthId);
        Task<ApiResponse<int>> UpdateUserAsync(int userId, UserProfileDto user);

        Task<ApiResponse<int>> DeleteUserAsync(int userAuthId);
        Task<ApiResponse<IEnumerable<UserProfile>>> GetAllAsync();
        Task<ApiResponse<UserProfile?>> GetByAuthIdAsync(int userAuthId);
          }
}
