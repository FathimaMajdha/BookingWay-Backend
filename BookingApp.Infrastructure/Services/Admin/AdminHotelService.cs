using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using BookingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminHotelService : IAdminHotelService
    {
        private readonly IAdminHotelRepository _repo;

        public AdminHotelService(IAdminHotelRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<int>> AddHotelAsync(AdminHotelDto dto)
        {
            try
            {
                var result = await _repo.AddHotelAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelAsync(int hotelId, AdminHotelDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Hotel DTO cannot be null.");

            try
            {
                var result = await _repo.UpdateHotelAsync(hotelId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelAsync(int hotelId)
        {
            try
            {
                var result = await _repo.DeleteHotelAsync(hotelId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminHotel>>> GetAllHotelsAsync(int? hotelSearchId = null)
        {
            try
            {
                var result = await _repo.GetAllHotelsAsync(hotelSearchId);
                return ApiResponse<IEnumerable<AdminHotel>>.SuccessResponse(result, "Hotels fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminHotel>>.FailResponse($"Error fetching hotels: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminHotel?>> GetHotelByIdAsync(int hotelId)
        {
            try
            {
                var result = await _repo.GetHotelByIdAsync(hotelId);
                if (result == null)
                    return ApiResponse<AdminHotel?>.FailResponse("Hotel not found.");

                return ApiResponse<AdminHotel?>.SuccessResponse(result, "Hotel fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminHotel?>.FailResponse($"Error fetching hotel: {ex.Message}");
            }
        }
    }
}
