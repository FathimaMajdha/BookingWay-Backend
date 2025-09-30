using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminHotelLocationService : IAdminHotelLocationService
    {
        private readonly IAdminHotelLocationRepository _repository;

        public AdminHotelLocationService(IAdminHotelLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddLocationAsync(AdminHotelLocationDto dto)
        {
            try
            {
                var result = await _repository.AddHotelLocationAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel location added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel location: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateLocationAsync(int locationId, AdminHotelLocationDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Location DTO cannot be null.");

            try
            {
                var result = await _repository.UpdateHotelLocationAsync(locationId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel location updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel location: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteLocationAsync(int locationId)
        {
            try
            {
                var result = await _repository.DeleteHotelLocationAsync(locationId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel location deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel location: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminHotelLocation>>> GetAllLocationsAsync()
        {
            try
            {
                var result = await _repository.GetAllHotelLocationAsync();
                return ApiResponse<IEnumerable<AdminHotelLocation>>.SuccessResponse(result, "Hotel locations fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminHotelLocation>>.FailResponse($"Error fetching hotel locations: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminHotelLocation?>> GetLocationByIdAsync(int locationId)
        {
            try
            {
                var result = await _repository.GetHotelLocationByIdAsync(locationId);
                if (result == null)
                    return ApiResponse<AdminHotelLocation?>.FailResponse("Hotel location not found.");

                return ApiResponse<AdminHotelLocation?>.SuccessResponse(result, "Hotel location fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminHotelLocation?>.FailResponse($"Error fetching hotel location: {ex.Message}");
            }
        }
    }
}
