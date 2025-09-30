using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminFlightFareService
    {
        Task<ApiResponse<int>> AddFlightFareAsync(AdminFlightFareDto dto);
        Task<ApiResponse<int>> UpdateFlightFareAsync(int fareId, AdminFlightFareDto dto);
        Task<ApiResponse<int>> DeleteFlightFareAsync(int fareId);
        Task<ApiResponse<IEnumerable<AdminFlightFare>>> GetAllFlightFaresAsync(int? flightId = null);
        Task<ApiResponse<AdminFlightFare?>> GetFlightFareByIdAsync(int fareId);
    }
}