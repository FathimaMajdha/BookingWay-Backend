using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelDetailRepository
    {
        Task<IEnumerable<HotelDetailDto>> GetHotelDetailsAsync();
        Task<HotelDetailDto> GetHotelDetailByIdAsync(int hotelDetailId);
        Task<int> DeleteHotelDetailAsync(int hotelDetailId);


    }
}
