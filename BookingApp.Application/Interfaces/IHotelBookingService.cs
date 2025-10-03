using BookingApp.Application.Common;
using BookingApp.Application.DTO;
using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelBookingService
    {
        Task<ApiResponse<int>> CreateBookingAsync(HotelBookingDto dto, int userAuthId);
        Task<ApiResponse<IEnumerable<HotelBooking>>> GetBookingsByUserAsync(int userAuthId);
        Task<ApiResponse<int>> UpdateBookingAsync(int bookingId, RazorpayVerificationRequest dto);
        Task<ApiResponse<int>> DeleteBookingAsync(int bookingId);
        Task<ApiResponse<IEnumerable<HotelBooking>>> GetAllBookingsAsync();
        Task<ApiResponse<HotelBooking?>> GetBookingByIdAsync(int bookingId);
            
    }

}




