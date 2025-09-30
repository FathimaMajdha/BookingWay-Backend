using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class HotelDetailService : IHotelDetailService
    {
        private readonly IHotelDetailRepository _repository;

        public HotelDetailService(IHotelDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<HotelDetailDto>>> GetHotelDetailsAsync()
        {
            try
            {
                var result = await _repository.GetHotelDetailsAsync();
                return ApiResponse<IEnumerable<HotelDetailDto>>.SuccessResponse(result, "Hotel details fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelDetailDto>>.FailResponse($"Error fetching hotel details: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelDetailDto?>> GetHotelDetailByIdAsync(int hotelDetailId)
        {
            if (hotelDetailId <= 0)
                return ApiResponse<HotelDetailDto?>.FailResponse("Invalid hotel detail Id.");

            try
            {
                var result = await _repository.GetHotelDetailByIdAsync(hotelDetailId);
                if (result == null)
                    return ApiResponse<HotelDetailDto?>.FailResponse("Hotel detail not found.");

                return ApiResponse<HotelDetailDto?>.SuccessResponse(result, "Hotel detail fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelDetailDto?>.FailResponse($"Error fetching hotel detail: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelDetailAsync(int hotelDetailId)
        {
            if (hotelDetailId <= 0)
                return ApiResponse<int>.FailResponse("Invalid hotel detail Id.");

            try
            {
                var result = await _repository.DeleteHotelDetailAsync(hotelDetailId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel detail deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel detail: {ex.Message}");
            }
        }
    }
}
