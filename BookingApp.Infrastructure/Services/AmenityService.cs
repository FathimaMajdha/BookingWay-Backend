using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly IAmenityRepository _repository;

        public AmenityService(IAmenityRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddAmenityAsync(AmenityDto dto)
        {
            try
            {
                var result = await _repository.AddAmenityAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Amenity added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding amenity: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateAmenityAsync(int amenityId, AmenityDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Amenity DTO cannot be null.");

            try
            {
                var result = await _repository.UpdateAmenityAsync(amenityId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Amenity updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating amenity: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteAmenityAsync(int amenityId)
        {
            try
            {
                var result = await _repository.DeleteAmenityAsync(amenityId);
                return ApiResponse<int>.SuccessResponse(result, "Amenity deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting amenity: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Amenity>>> GetAllAmenitiesAsync()
        {
            try
            {
                var result = await _repository.GetAllAmenitiesAsync();
                return ApiResponse<IEnumerable<Amenity>>.SuccessResponse(result, "Amenities fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Amenity>>.FailResponse($"Error fetching amenities: {ex.Message}");
            }
        }

        public async Task<ApiResponse<Amenity?>> GetAmenityByIdAsync(int amenityId)
        {
            try
            {
                var result = await _repository.GetAmenityByIdAsync(amenityId);
                if (result == null)
                    return ApiResponse<Amenity?>.FailResponse("Amenity not found.");

                return ApiResponse<Amenity?>.SuccessResponse(result, "Amenity fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<Amenity?>.FailResponse($"Error fetching amenity: {ex.Message}");
            }
        }
    }
}
