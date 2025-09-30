using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using BookingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminHotelDiningService : IAdminHotelDiningService
    {
        private readonly IAdminHotelDiningRepository _repository;

        public AdminHotelDiningService(IAdminHotelDiningRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddHotelDiningAsync(AdminHotelDiningDto dto)
        {
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

        public async Task<ApiResponse<int>> UpdateHotelDiningAsync(int diningId, AdminHotelDiningDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Dining DTO cannot be null.");

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

        public async Task<ApiResponse<IEnumerable<AdminHotelDining>>> GetAllHotelDiningAsync()
        {
            try
            {
                var result = await _repository.GetAllDiningAsync();
                return ApiResponse<IEnumerable<AdminHotelDining>>.SuccessResponse(result, "Hotel dining list fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminHotelDining>>.FailResponse($"Error fetching hotel dining list: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminHotelDining?>> GetDiningByIdAsync(int diningId)
        {
            try
            {
                var result = await _repository.GetDiningByIdAsync(diningId);
                if (result == null)
                    return ApiResponse<AdminHotelDining?>.FailResponse("Hotel dining not found.");

                return ApiResponse<AdminHotelDining?>.SuccessResponse(result, "Hotel dining fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminHotelDining?>.FailResponse($"Error fetching hotel dining: {ex.Message}");
            }
        }
    }
}
