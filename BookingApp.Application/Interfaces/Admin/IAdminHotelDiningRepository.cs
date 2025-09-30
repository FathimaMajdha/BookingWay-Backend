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
    public interface IAdminHotelDiningRepository
    {
        Task<int> AddDiningAsync(AdminHotelDiningDto dto);
        Task<int> UpdateDiningAsync(int diningId, AdminHotelDiningDto dto);
        Task<int> DeleteDiningAsync(int diningId);
        Task<IEnumerable<AdminHotelDining>> GetAllDiningAsync();
        Task<AdminHotelDining> GetDiningByIdAsync(int diningId);
           
    }
}
