using BookingApp.Domain.Entities;

namespace BookingApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<UserAuth?> GetByLoginAsync(string username, string password);
        Task<UserAuth?> RegisterUserAsync(UserAuth user);


    }
}
