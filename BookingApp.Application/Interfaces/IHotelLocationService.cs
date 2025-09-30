using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelLocationService
    {
        Task<ApiResponse<int>> AddLocationAsync(CreateHotelLocationDto dto);
        Task<ApiResponse<int>> UpdateLocationAsync(int locationId, CreateHotelLocationDto dto);
        Task<ApiResponse<int>> DeleteLocationAsync(int locationId);
        Task<ApiResponse<IEnumerable<HotelLocation>>> GetAllLocationsAsync();
        Task<ApiResponse<HotelLocation?>> GetLocationByIdAsync(int locationId);
           
    }
}
