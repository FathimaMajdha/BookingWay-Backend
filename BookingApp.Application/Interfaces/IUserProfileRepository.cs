using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<int> AddUserAsync(int userAuthId, UserProfileDto user);

        Task<int> UpdateUserAsync(int userId, UserProfileDto user);
        Task<int> DeleteUserAsync(int userAuthId);
        Task<IEnumerable<UserProfile>> GetAllAsync();
        Task<UserProfile?> GetByAuthIdAsync(int userAuthId);
    }
}
