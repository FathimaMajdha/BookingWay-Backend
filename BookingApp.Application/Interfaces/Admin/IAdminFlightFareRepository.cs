using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminFlightFareRepository
    {
        Task<int> AddFlightFareAsync(AdminFlightFareDto dto);
        Task<int> UpdateFlightFareAsync(int fareId, AdminFlightFareDto dto);
        Task<int> DeleteFlightFareAsync(int fareId);
        Task<IEnumerable<AdminFlightFare>> GetAllFlightFaresAsync(int? flightId = null);
        Task<AdminFlightFare?> GetFlightFareByIdAsync(int fareId);
    }
}