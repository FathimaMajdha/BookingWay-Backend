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
    public interface IAdminHotelRepository
    {

        Task<int> AddHotelAsync(AdminHotelDto dto);
        Task<int> UpdateHotelAsync(int hotelId, AdminHotelDto dto);
        Task<int> DeleteHotelAsync(int hotelId);
        Task<IEnumerable<AdminHotel>> GetAllHotelsAsync(int? hotelSearchId = null);
        Task<AdminHotel?> GetHotelByIdAsync(int hotelId);

    }
}
