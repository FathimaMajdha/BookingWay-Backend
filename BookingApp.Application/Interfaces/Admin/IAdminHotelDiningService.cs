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
    public interface IAdminHotelDiningService
    {
        Task<ApiResponse<int>> AddHotelDiningAsync(AdminHotelDiningDto dto);
        Task<ApiResponse<int>> UpdateHotelDiningAsync(int diningId, AdminHotelDiningDto dto);
        Task<ApiResponse<int>> DeleteHotelDiningAsync(int diningId);
        Task<ApiResponse<IEnumerable<AdminHotelDining>>> GetAllHotelDiningAsync();
        Task<ApiResponse<AdminHotelDining?>> GetDiningByIdAsync(int diningId);
           
        
    }


}
