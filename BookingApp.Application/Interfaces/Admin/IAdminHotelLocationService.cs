using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
   public interface IAdminHotelLocationService
    {
        Task<ApiResponse<int>> AddLocationAsync(AdminHotelLocationDto dto);
        Task<ApiResponse<int>> UpdateLocationAsync(int locationId, AdminHotelLocationDto dto);
        Task<ApiResponse<int>> DeleteLocationAsync(int locationId);
        Task<ApiResponse<IEnumerable<AdminHotelLocation>>> GetAllLocationsAsync();
        Task<ApiResponse<AdminHotelLocation?>> GetLocationByIdAsync(int locationId);
           
    }

}

