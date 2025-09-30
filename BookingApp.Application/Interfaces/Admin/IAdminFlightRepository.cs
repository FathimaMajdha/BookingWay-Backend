using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Entities.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminFlightRepository
    {
       
        Task<int> AddFlightSearchAsync(SearchDto dto);
        Task<int> UpdateFlightSearchAsync(int flightSearchId, FlightSearchDto dto);
        Task<int> DeleteFlightSearchAsync(int flightSearchId);
        Task<IEnumerable<FlightSearch>> GetAllFlightSearchAsync();
        Task<FlightSearch?> GetFlightSearchByIdAsync(int flightSearchId);

     
        Task<int> AddFlightAsync(AdminFlightDto dto);
        Task<int> UpdateFlightAsync(int flightId, AdminFlightDto dto);
        Task<int> DeleteFlightAsync(int flightId);
        Task<IEnumerable<AdminFlight>> GetAllFlightsAsync(int? flightSearchId = null);
        Task<AdminFlight?> GetFlightByIdAsync(int flightId);
    }
}
