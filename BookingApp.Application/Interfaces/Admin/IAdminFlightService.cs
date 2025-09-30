using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Entities.Admin;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminFlightService
    {
        Task<ApiResponse<int>> AddFlightSearchAsync(SearchDto dto);
        Task<ApiResponse<int>> UpdateFlightSearchAsync(int flightSearchId, FlightSearchDto dto);
        Task<ApiResponse<int>> DeleteFlightSearchAsync(int flightSearchId);
        Task<ApiResponse<IEnumerable<FlightSearch>>> GetAllFlightSearchAsync();
        Task<ApiResponse<FlightSearch?>> GetFlightSearchByIdAsync(int flightSearchId);
        Task<ApiResponse<int>> AddFlightAsync(AdminFlightDto dto);

        Task<ApiResponse<int>> UpdateFlightAsync(int flightId, AdminFlightDto dto);
        Task<ApiResponse<int>> DeleteFlightAsync(int flightId);
        Task<ApiResponse<IEnumerable<AdminFlight>>> GetAllFlightsAsync(int? flightSearchId = null);
        Task<ApiResponse<AdminFlight?>> GetFlightByIdAsync(int flightId);

    }
    

}
