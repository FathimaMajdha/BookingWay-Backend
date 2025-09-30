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
    public class AdminHotelPolicyService : IAdminHotelPolicyService
    {
        private readonly IAdminHotelPolicyRepository _repo;

        public AdminHotelPolicyService(IAdminHotelPolicyRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<int>> AddHotelpolicyAsync(AdminHotelPolicyDto dto)
        {
            try
            {
                var result = await _repo.AddHotelPolicyAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel policy added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel policy: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelpolicyAsync(int policyId, AdminHotelPolicyDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Policy DTO cannot be null.");

            try
            {
                var result = await _repo.UpdateHotelPolicyAsync(policyId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel policy updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel policy: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelpolicyAsync(int policyId)
        {
            try
            {
                var result = await _repo.DeleteHotelPolicyAsync(policyId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel policy deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel policy: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminHotelPolicy>>> GetAllHotelPolicyAsync(int? hotelId = null)
        {
            try
            {
                var result = await _repo.GetAllHotelPolicyAsync(hotelId);
                return ApiResponse<IEnumerable<AdminHotelPolicy>>.SuccessResponse(result, "Hotel policies fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminHotelPolicy>>.FailResponse($"Error fetching hotel policies: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminHotelPolicy?>> GetHotelPolicyByIdAsync(int policyId)
        {
            try
            {
                var result = await _repo.GetHotelPolicyByIdAsync(policyId);
                if (result == null)
                    return ApiResponse<AdminHotelPolicy?>.FailResponse("Hotel policy not found.");

                return ApiResponse<AdminHotelPolicy?>.SuccessResponse(result, "Hotel policy fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminHotelPolicy?>.FailResponse($"Error fetching hotel policy: {ex.Message}");
            }
        }
    }
}
