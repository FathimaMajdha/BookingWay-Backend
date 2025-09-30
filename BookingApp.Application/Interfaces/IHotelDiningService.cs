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
    public interface IHotelDiningService
    {
        Task<ApiResponse<int>> AddHotelDiningAsync(HotelDiningDto dto);
        Task<ApiResponse<int>> UpdateHotelDiningAsync(int diningId, HotelDiningDto dto);
        Task<ApiResponse<int>> DeleteHotelDiningAsync(int diningId);
        Task<ApiResponse<IEnumerable<HotelDining>>> GetAllHotelDiningAsync();
        Task<ApiResponse<HotelDining?>> GetDiningByIdAsync(int diningId);
           
    }

}

