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
    public interface IHotelDetailService
    {
        Task<ApiResponse<IEnumerable<HotelDetailDto>>> GetHotelDetailsAsync();
        Task<ApiResponse<HotelDetailDto?>> GetHotelDetailByIdAsync(int hotelDetailId);
        Task<ApiResponse<int>> DeleteHotelDetailAsync(int hotelDetailId);
       
    }

}

