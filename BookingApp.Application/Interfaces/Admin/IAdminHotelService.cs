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
    public interface IAdminHotelService
    {
        Task<ApiResponse<int>> AddHotelAsync(AdminHotelDto dto);
        Task<ApiResponse<int>> UpdateHotelAsync(int hotelId, AdminHotelDto dto);
        Task<ApiResponse<int>> DeleteHotelAsync(int hotelId);
        Task<ApiResponse<IEnumerable<AdminHotel>>> GetAllHotelsAsync(int? hotelSearchId = null);
        Task<ApiResponse<AdminHotel?>> GetHotelByIdAsync(int hotelId);
    }

}

