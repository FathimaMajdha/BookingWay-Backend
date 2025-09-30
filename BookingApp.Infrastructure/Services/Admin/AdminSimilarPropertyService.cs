using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminSimilarPropertyService : IAdminSimilarPropertyService
    {
        private readonly IAdminSimilarPropertyRepository _repository;

        public AdminSimilarPropertyService(IAdminSimilarPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddpropAsync(AdminSimilarPropertyDto dto)
        {
            try
            {
                var result = await _repository.AddSimilarPropAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Similar property added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding similar property: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdatepropAsync(int propId, AdminSimilarPropertyDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Similar property DTO cannot be null.");

            try
            {
                var result = await _repository.UpdateSimilarPropAsync(propId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Similar property updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating similar property: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeletepropAsync(int propId)
        {
            try
            {
                var result = await _repository.DeleteSimilarPropAsync(propId);
                return ApiResponse<int>.SuccessResponse(result, "Similar property deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting similar property: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminSimilarProperty>>> GetAllpropsAsync()
        {
            try
            {
                var result = await _repository.GetAllSimilarPropAsync();
                return ApiResponse<IEnumerable<AdminSimilarProperty>>.SuccessResponse(result, "Similar properties fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminSimilarProperty>>.FailResponse($"Error fetching similar properties: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminSimilarProperty?>> GetpropByIdAsync(int propId)
        {
            try
            {
                var result = await _repository.GetSimilarPropByIdAsync(propId);
                if (result == null)
                    return ApiResponse<AdminSimilarProperty?>.FailResponse("Similar property not found.");

                return ApiResponse<AdminSimilarProperty?>.SuccessResponse(result, "Similar property fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminSimilarProperty?>.FailResponse($"Error fetching similar property: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminSimilarPropertyDto>>> GetSimilarPropertiesAsync(int hotelId)
        {
            try
            {
                var result = await _repository.GetSimilarPropertiesAsync(hotelId);
                return ApiResponse<IEnumerable<AdminSimilarPropertyDto>>.SuccessResponse(result, "Similar properties fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminSimilarPropertyDto>>.FailResponse($"Error fetching similar properties: {ex.Message}");
            }
        }
    }
}
