using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IFlightFareRepository
    {
        Task<int> AddFareAsync(FlightFareDto dto);
        Task<int> UpdateFareAsync(int fareId, FlightFareDto dto);
        Task<int> DeleteFareAsync(int fareId);
        Task<IEnumerable<FlightFare>> GetAllFaresAsync();
        Task<FlightFare?> GetFareByIdAsync(int fareId);
        Task<IEnumerable<FlightFare>> GetFaresByFlightIdAsync(int flightId);


    }
}
