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
   public interface IAdminAmenitiesRepository
    {
        Task<int> AddHotelAmenityAsync(AdminAmenityDto dto);
        Task<int> UpdateHotelAmenityAsync(int amenityId, AdminAmenityDto dto);
        Task<int> DeleteHotelAmenityAsync(int amenityId);
        Task<IEnumerable<AdminAmenity>> GetAllHotelAmenityAsync(int? hotelId = null);
        Task<AdminAmenity?> GetHotelAmenityByIdAsync(int amenityId);
        
    }
}
