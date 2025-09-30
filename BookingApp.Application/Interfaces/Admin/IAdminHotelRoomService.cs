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
    public interface IAdminHotelRoomService
    {
        Task<ApiResponse<int>> AddHotelRoomAsync(AdminHotelRoomDto dto);
        Task<ApiResponse<int>> UpdateHotelRoomAsync(int roomId, AdminHotelRoomDto dto);
        Task<ApiResponse<int>> DeleteHotelRoomAsync(int roomId);
        Task<ApiResponse<IEnumerable<AdminHotelRoom>>> GetAllHotelRoomAsync(int? hotelId = null);
        Task<ApiResponse<AdminHotelRoom?>> GetHotelRoomByIdAsync(int roomId);
           
    }


}
