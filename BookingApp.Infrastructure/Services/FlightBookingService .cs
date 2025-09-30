using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class FlightBookingService : IFlightBookingService
    {
        private readonly IFlightBookingRepository _repository;

        public FlightBookingService(IFlightBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> CreateBookingAsync(FlightBookingDto dto)
        {
            try
            {
                var result = await _repository.AddBookingAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Booking created successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error creating booking: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateBookingAsync(int bookingId, VerifyPaymentDto dto)
        {
            try
            {
                var result = await _repository.UpdateBookingAsync(bookingId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Booking updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating booking: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteBookingAsync(int bookingId)
        {
            try
            {
                var result = await _repository.DeleteBookingAsync(bookingId);
                return ApiResponse<int>.SuccessResponse(result, "Booking deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting booking: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightBooking>>> GetAllBookingsAsync()
        {
            try
            {
                var result = await _repository.GetAllBookingsAsync();
                return ApiResponse<IEnumerable<FlightBooking>>.SuccessResponse(result, "Bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightBooking>>.FailResponse($"Error fetching bookings: {ex.Message}");
            }
        }

        public async Task<ApiResponse<FlightBooking?>> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                var result = await _repository.GetBookingByIdAsync(bookingId);
                if (result == null)
                    return ApiResponse<FlightBooking?>.FailResponse("Booking not found.");

                return ApiResponse<FlightBooking?>.SuccessResponse(result, "Booking fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<FlightBooking?>.FailResponse($"Error fetching booking: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightBooking>>> GetBookingsByFlightIdAsync(int flightId)
        {
            try
            {
                var result = await _repository.GetBookingsByFlightIdAsync(flightId);
                return ApiResponse<IEnumerable<FlightBooking>>.SuccessResponse(result, "Bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightBooking>>.FailResponse($"Error fetching bookings: {ex.Message}");
            }
        }
    }
}
