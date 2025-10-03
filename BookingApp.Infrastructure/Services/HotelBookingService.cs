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
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IHotelBookingRepository _repository;

        public HotelBookingService(IHotelBookingRepository repository)
        {
            _repository = repository;
        }

        // UPDATE method signature to include userAuthId
        public async Task<ApiResponse<int>> CreateBookingAsync(HotelBookingDto dto, int userAuthId)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Booking data cannot be null.");

            try
            {
                var result = await _repository.AddBookingAsync(dto, userAuthId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel booking created successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error creating booking: {ex.Message}");
            }
        }

        // ADD NEW METHOD FOR USER-SPECIFIC BOOKINGS
        public async Task<ApiResponse<IEnumerable<HotelBooking>>> GetBookingsByUserAsync(int userAuthId)
        {
            try
            {
                var result = await _repository.GetBookingsByUserAsync(userAuthId);
                return ApiResponse<IEnumerable<HotelBooking>>.SuccessResponse(result, "User hotel bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelBooking>>.FailResponse($"Error fetching user bookings: {ex.Message}");
            }
        }

        // Rest of your existing methods remain the same...
        public async Task<ApiResponse<int>> UpdateBookingAsync(int bookingId, RazorpayVerificationRequest dto)
        {
            if (bookingId <= 0)
                return ApiResponse<int>.FailResponse("Invalid booking Id.");
            if (dto == null)
                return ApiResponse<int>.FailResponse("Booking update data cannot be null.");

            try
            {
                var result = await _repository.UpdateBookingAsync(bookingId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel booking updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating booking: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteBookingAsync(int bookingId)
        {
            if (bookingId <= 0)
                return ApiResponse<int>.FailResponse("Invalid booking Id.");

            try
            {
                var result = await _repository.DeleteBookingAsync(bookingId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel booking deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting booking: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelBooking>>> GetAllBookingsAsync()
        {
            try
            {
                var result = await _repository.GetAllBookingsAsync();
                return ApiResponse<IEnumerable<HotelBooking>>.SuccessResponse(result, "All hotel bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelBooking>>.FailResponse($"Error fetching bookings: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelBooking?>> GetBookingByIdAsync(int bookingId)
        {
            if (bookingId <= 0)
                return ApiResponse<HotelBooking?>.FailResponse("Invalid booking Id.");

            try
            {
                var result = await _repository.GetBookingByIdAsync(bookingId);
                if (result == null)
                    return ApiResponse<HotelBooking?>.FailResponse("Booking not found.");

                return ApiResponse<HotelBooking?>.SuccessResponse(result, "Booking fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelBooking?>.FailResponse($"Error fetching booking: {ex.Message}");
            }
        }
    }
}