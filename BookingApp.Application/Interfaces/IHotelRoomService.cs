using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelRoomService
    {

        Task<ApiResponse<int>> AddRoomAsync(HotelRoomDto dto);

        Task<ApiResponse<HotelRoomDto?>> UpdateRoomAsync(int roomId, HotelRoomDto dto);
        Task<ApiResponse<int>> DeleteRoomAsync(int roomId);
        Task<ApiResponse<IEnumerable<HotelRoom>>> GetAllRoomsAsync();
        Task<ApiResponse<HotelRoom?>> GetRoomByIdAsync(int roomId);
           
    }
}
