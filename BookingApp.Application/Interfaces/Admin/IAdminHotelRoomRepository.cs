using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminHotelRoomRepository
    {

        Task<int> AddHotelRoomAsync(AdminHotelRoomDto dto);
        Task<int> UpdateHotelRoomAsync(int roomId, AdminHotelRoomDto dto);
        Task<int> DeleteHotelRoomAsync(int roomId);
        Task<IEnumerable<AdminHotelRoom>> GetAllHotelRoomAsync(int? hotelId = null);
        Task<AdminHotelRoom?> GetHotelRoomByIdAsync(int roomId);
    }
}
