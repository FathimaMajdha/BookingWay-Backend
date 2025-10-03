using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IFlightBookingService
    {
        Task<ApiResponse<int>> CreateBookingAsync(FlightBookingDto dto);
        Task<ApiResponse<int>> UpdateBookingAsync(int bookingId, RazorpayVerificationRequest dto);
        Task<ApiResponse<int>> DeleteBookingAsync(int bookingId);
        Task<ApiResponse<IEnumerable<FlightBooking>>> GetAllBookingsAsync();
        Task<ApiResponse<FlightBooking?>> GetBookingByIdAsync(int bookingId);
        Task<ApiResponse<IEnumerable<FlightBooking>>> GetBookingsByFlightIdAsync(int flightId);
          
    }

}

