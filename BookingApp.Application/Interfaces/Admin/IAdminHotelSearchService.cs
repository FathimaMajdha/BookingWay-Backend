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
    public interface IAdminHotelSearchService
    {
        Task<ApiResponse<int>> AddHotelSearchAsync(AdminHotelSearchDto dto);
        Task<ApiResponse<int>> UpdateHotelSearchAsync(int hotelSearchId, AdminHotelSearchDto dto);
        Task<ApiResponse<int>> DeleteHotelSearchAsync(int hotelSearchId);
        Task<ApiResponse<IEnumerable<AdminHotelSearch>>> GetAllHotelSearchesAsync();
        Task<ApiResponse<AdminHotelSearch?>> GetHotelSearchByIdAsync(int hotelSearchId);
           
    }

}

