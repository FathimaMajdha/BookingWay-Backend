using BookingApp.Application.DTO;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelBookingRepository
    {
        Task<int> AddBookingAsync(HotelBookingDto dto);
        Task<int> UpdateBookingAsync(int bookingId, VerifyPaymentDto dto);
        Task<int> DeleteBookingAsync(int bookingId);
        Task<IEnumerable<HotelBooking>> GetAllBookingsAsync();
        Task<HotelBooking?> GetBookingByIdAsync(int bookingId);
    }
}
