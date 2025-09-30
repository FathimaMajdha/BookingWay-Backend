using BookingApp.Application.Common;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IFlightFareService
    {

        Task<ApiResponse<int>> AddfareAsync(FlightFareDto dto);
        Task<ApiResponse<int>> UpdatefareAsync(int fareId, FlightFareDto dto);
        Task<ApiResponse<int>> DeletefareAsync(int fareId);
        Task<ApiResponse<IEnumerable<FlightFare>>> GetAllfaresAsync();
        Task<ApiResponse<FlightFare?>> GetfareByIdAsync(int fareId);
        Task<ApiResponse<IEnumerable<FlightFare>>> GetfaresbyflightAsync(int flightId);
           
    }


}

