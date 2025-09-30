using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminHotelSearchService : IAdminHotelSearchService
    {
        private readonly IAdminHotelSearchRepository _repo;

        public AdminHotelSearchService(IAdminHotelSearchRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<int>> AddHotelSearchAsync(AdminHotelSearchDto dto)
        {
            try
            {
                var result = await _repo.AddHotelSearchAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel search added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelSearchAsync(int hotelSearchId, AdminHotelSearchDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Hotel search DTO cannot be null.");

            try
            {
                var result = await _repo.UpdateHotelSearchAsync(hotelSearchId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel search updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelSearchAsync(int hotelSearchId)
        {
            try
            {
                var result = await _repo.DeleteHotelSearchAsync(hotelSearchId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel search deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminHotelSearch>>> GetAllHotelSearchesAsync()
        {
            try
            {
                var result = await _repo.GetAllHotelSearchesAsync();
                return ApiResponse<IEnumerable<AdminHotelSearch>>.SuccessResponse(result, "Hotel searches fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminHotelSearch>>.FailResponse($"Error fetching hotel searches: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminHotelSearch?>> GetHotelSearchByIdAsync(int hotelSearchId)
        {
            try
            {
                var result = await _repo.GetHotelSearchByIdAsync(hotelSearchId);
                if (result == null)
                    return ApiResponse<AdminHotelSearch?>.FailResponse("Hotel search not found.");

                return ApiResponse<AdminHotelSearch?>.SuccessResponse(result, "Hotel search fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminHotelSearch?>.FailResponse($"Error fetching hotel search: {ex.Message}");
            }
        }
    }
}
