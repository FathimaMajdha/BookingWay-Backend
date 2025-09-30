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
   public interface IAdminHotelLocationRepository
    {

        Task<int> AddHotelLocationAsync(AdminHotelLocationDto dto);
        Task<int> UpdateHotelLocationAsync(int locationId, AdminHotelLocationDto dto);
        Task<int> DeleteHotelLocationAsync(int locationId);
        Task<IEnumerable<AdminHotelLocation>> GetAllHotelLocationAsync();

        Task<AdminHotelLocation> GetHotelLocationByIdAsync(int locationId);
          
    }
}
