using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminHotelSearchRepository
    {
        Task<int> AddHotelSearchAsync(AdminHotelSearchDto dto);
        Task<int> UpdateHotelSearchAsync(int hotelSearchId, AdminHotelSearchDto dto);
        Task<int> DeleteHotelSearchAsync(int hotelSearchId);
        Task<IEnumerable<AdminHotelSearch>> GetAllHotelSearchesAsync();
        Task<AdminHotelSearch?> GetHotelSearchByIdAsync(int hotelSearchId);
    }
}
