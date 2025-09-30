using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class HotelLocationService : IHotelLocationService
    {
        private readonly IHotelLocationRepository _repository;

        public HotelLocationService(IHotelLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddLocationAsync(CreateHotelLocationDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid location data.");

            try
            {
                var result = await _repository.AddLocationAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel location added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding location: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateLocationAsync(int locationId, CreateHotelLocationDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid location data.");

            try
            {
                var result = await _repository.UpdateLocationAsync(locationId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel location updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating location: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteLocationAsync(int locationId)
        {
            if (locationId <= 0) return ApiResponse<int>.FailResponse("Invalid location Id.");

            try
            {
                var result = await _repository.DeleteLocationAsync(locationId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel location deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting location: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelLocation>>> GetAllLocationsAsync()
        {
            try
            {
                var result = await _repository.GetAllLocationAsync();
                return ApiResponse<IEnumerable<HotelLocation>>.SuccessResponse(result, "Hotel locations fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelLocation>>.FailResponse($"Error fetching locations: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelLocation?>> GetLocationByIdAsync(int locationId)
        {
            if (locationId <= 0) return ApiResponse<HotelLocation?>.FailResponse("Invalid location Id.");

            try
            {
                var result = await _repository.GetLocationByIdAsync(locationId);
                if (result == null) return ApiResponse<HotelLocation?>.FailResponse("Location not found.");
                return ApiResponse<HotelLocation?>.SuccessResponse(result, "Hotel location fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelLocation?>.FailResponse($"Error fetching location: {ex.Message}");
            }
        }
    }
}
