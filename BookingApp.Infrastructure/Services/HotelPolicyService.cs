using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class HotelPolicyService : IHotelPolicyService
    {
        private readonly IHotelPolicyRepository _repo;

        public HotelPolicyService(IHotelPolicyRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<int>> AddpolicyAsync(CreateHotelPolicyDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid policy data.");
            try
            {
                var result = await _repo.AddpolicyAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel policy added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding policy: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdatePolicyAsync(int policyId, CreateHotelPolicyDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid policy data.");
            try
            {
                var result = await _repo.UpdatePolicyAsync(policyId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel policy updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating policy: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeletePolicyAsync(int policyId)
        {
            try
            {
                var result = await _repo.DeletePolicyAsync(policyId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel policy deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting policy: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelPolicy>>> GetAllPolicyAsync()
        {
            try
            {
                var result = await _repo.GetAllPolicyAsync();
                return ApiResponse<IEnumerable<HotelPolicy>>.SuccessResponse(result, "Policies fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelPolicy>>.FailResponse($"Error fetching policies: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelPolicy?>> GetPolicyByIdAsync(int policyId)
        {
            try
            {
                var result = await _repo.GetPolicyByIdAsync(policyId);
                if (result == null) return ApiResponse<HotelPolicy?>.FailResponse("Policy not found.");
                return ApiResponse<HotelPolicy?>.SuccessResponse(result, "Policy fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelPolicy?>.FailResponse($"Error fetching policy: {ex.Message}");
            }
        }
    }
}
