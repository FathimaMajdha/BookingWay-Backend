using BookingApp.Application.Common;
using BookingApp.Application.DTO;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<MyBookingDto>>> GetMyBookingsAsync(int userAuthId)
        {
            try
            {
                var bookings = await _repository.GetMyBookingsAsync(userAuthId);
                return ApiResponse<IEnumerable<MyBookingDto>>.SuccessResponse(bookings, "Bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetMyBookingsAsync: {ex.Message}");
                return ApiResponse<IEnumerable<MyBookingDto>>.FailResponse("Error fetching bookings.");
            }
        }
    }
}
