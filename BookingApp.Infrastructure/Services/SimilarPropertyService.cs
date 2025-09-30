using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class SimilarPropertyService : ISimilarPropertyService
    {
        private readonly ISimilarPropertyRepository _repository;

        public SimilarPropertyService(ISimilarPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddpropAsync(SimilarPropertyDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid property data.");
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

        public async Task<ApiResponse<int>> UpdatepropAsync(int propId, SimilarPropertyDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid property data.");
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

        public async Task<ApiResponse<IEnumerable<SimilarProperty>>> GetAllpropsAsync()
        {
            try
            {
                var result = await _repository.GetAllSimilarPropAsync();
                return ApiResponse<IEnumerable<SimilarProperty>>.SuccessResponse(result, "All similar properties fetched.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<SimilarProperty>>.FailResponse($"Error fetching properties: {ex.Message}");
            }
        }

        public async Task<ApiResponse<SimilarProperty?>> GetpropByIdAsync(int propId)
        {
            try
            {
                var result = await _repository.GetSimilarPropByIdAsync(propId);
                if (result == null) return ApiResponse<SimilarProperty?>.FailResponse("Property not found.");
                return ApiResponse<SimilarProperty?>.SuccessResponse(result, "Property fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<SimilarProperty?>.FailResponse($"Error fetching property: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<SimilarPropertyDto>>> GetSimilarPropertiesAsync(int hotelId)
        {
            try
            {
                var result = await _repository.GetSimilarPropertiesAsync(hotelId);
                return ApiResponse<IEnumerable<SimilarPropertyDto>>.SuccessResponse(result, "Similar properties fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<SimilarPropertyDto>>.FailResponse($"Error fetching similar properties: {ex.Message}");
            }
        }
    }
}
