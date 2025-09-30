using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelRoomRepository
    {
        Task<int> AddRoomAsync(HotelRoomDto dto);
        Task<HotelRoomDto> UpdateRoomAsync(int roomId, HotelRoomDto dto);
        Task<int> DeleteRoomAsync(int roomId);
        Task<IEnumerable<HotelRoom>> GetAllRoomsAsync();
        Task<HotelRoom> GetRoomByIdAsync(int roomId);
    }
}
