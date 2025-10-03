using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
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
                var result = await _repository.GetMyBookingsAsync(userAuthId);
                return ApiResponse<IEnumerable<MyBookingDto>>.SuccessResponse(result, "All bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<MyBookingDto>>.FailResponse($"Error fetching bookings: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<MyBookingDto>>> GetMyFlightBookingsAsync(int userAuthId)
        {
            try
            {
                var result = await _repository.GetMyFlightBookingsAsync(userAuthId);
                return ApiResponse<IEnumerable<MyBookingDto>>.SuccessResponse(result, "Flight bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<MyBookingDto>>.FailResponse($"Error fetching flight bookings: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<MyBookingDto>>> GetMyHotelBookingsAsync(int userAuthId)
        {
            try
            {
                var result = await _repository.GetMyHotelBookingsAsync(userAuthId);
                return ApiResponse<IEnumerable<MyBookingDto>>.SuccessResponse(result, "Hotel bookings fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<MyBookingDto>>.FailResponse($"Error fetching hotel bookings: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteBookingAsync(int myBookingId, int userAuthId)
        {
            try
            {
                var result = await _repository.DeleteBookingAsync(myBookingId, userAuthId);
                if (result == 1)
                {
                    return ApiResponse<int>.SuccessResponse(result, "Booking deleted successfully.");
                }
                else
                {
                    return ApiResponse<int>.FailResponse("Failed to delete booking. Booking not found or you don't have permission.");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting booking: {ex.Message}");
            }
        }
    }
}