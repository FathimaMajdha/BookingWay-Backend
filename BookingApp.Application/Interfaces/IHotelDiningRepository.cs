using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelDiningRepository
    {
        Task<int> AddDiningAsync(HotelDiningDto dto);

        Task<int> UpdateDiningAsync(int diningId, HotelDiningDto dto);

        Task<int> DeleteDiningAsync(int diningId);

        Task<IEnumerable<HotelDining>> GetAllDiningAsync();

        Task<HotelDining> GetDiningByIdAsync(int diningId);
    }
}
