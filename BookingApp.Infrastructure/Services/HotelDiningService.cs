using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class HotelDiningService : IHotelDiningService
    {
        private readonly IHotelDiningRepository _repository;

        public HotelDiningService(IHotelDiningRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddHotelDiningAsync(HotelDiningDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Invalid dining data.");

            try
            {
                var result = await _repository.AddDiningAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel dining added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel dining: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelDiningAsync(int diningId, HotelDiningDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Invalid dining data.");

            try
            {
                var result = await _repository.UpdateDiningAsync(diningId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel dining updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel dining: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelDiningAsync(int diningId)
        {
            if (diningId <= 0)
                return ApiResponse<int>.FailResponse("Invalid dining Id.");

            try
            {
                var result = await _repository.DeleteDiningAsync(diningId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel dining deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel dining: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelDining>>> GetAllHotelDiningAsync()
        {
            try
            {
                var result = await _repository.GetAllDiningAsync();
                return ApiResponse<IEnumerable<HotelDining>>.SuccessResponse(result, "Hotel dining fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelDining>>.FailResponse($"Error fetching hotel dining: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelDining?>> GetDiningByIdAsync(int diningId)
        {
            if (diningId <= 0)
                return ApiResponse<HotelDining?>.FailResponse("Invalid dining Id.");

            try
            {
                var result = await _repository.GetDiningByIdAsync(diningId);
                if (result == null)
                    return ApiResponse<HotelDining?>.FailResponse("Dining record not found.");

                return ApiResponse<HotelDining?>.SuccessResponse(result, "Hotel dining fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelDining?>.FailResponse($"Error fetching hotel dining: {ex.Message}");
            }
        }
    }
}
