using BookingApp.Domain.Entities;


namespace BookingApp.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UserAuth user);
    }
}
