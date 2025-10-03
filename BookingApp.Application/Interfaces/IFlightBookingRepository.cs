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
    public interface IFlightBookingRepository
    {
        Task<int> AddBookingAsync(FlightBookingDto dto);
        Task<int> UpdateBookingAsync(int bookingId, RazorpayVerificationRequest dto);
        Task<int> DeleteBookingAsync(int bookingId);
        Task<IEnumerable<FlightBooking>> GetAllBookingsAsync();
        Task<FlightBooking?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<FlightBooking>> GetBookingsByFlightIdAsync(int flightId);
    }
}
