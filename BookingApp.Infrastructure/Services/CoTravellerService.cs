using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class CoTravellerService : ICoTravellerService
    {
        private readonly ICoTravellerRepository _repo;

        public CoTravellerService(ICoTravellerRepository repository)
        {
            _repo = repository;
        }

        public async Task<ApiResponse<int>> AddCoTravellerAsync(int userAuthId, CoTravellerDto traveller)
        {
            if (traveller == null)
                return ApiResponse<int>.FailResponse("CoTraveller data cannot be null.");

            if (string.IsNullOrEmpty(traveller.FirstName))
                return ApiResponse<int>.FailResponse("First Name is required.");

            try
            {
                var result = await _repo.AddCoTravellerAsync(userAuthId, traveller);
                return ApiResponse<int>.SuccessResponse(result, "CoTraveller added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding co-traveller: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateCoTravellerAsync(int coTravellerId, CoTravellerDto traveller)
        {
            if (traveller == null)
                return ApiResponse<int>.FailResponse("CoTraveller data cannot be null.");

            try
            {
                var result = await _repo.UpdateCoTravellerAsync(coTravellerId, traveller);
                return ApiResponse<int>.SuccessResponse(result, "CoTraveller updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating co-traveller: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteCoTravellerAsync(int coTravellerId)
        {
            if (coTravellerId <= 0)
                return ApiResponse<int>.FailResponse("Invalid CoTraveller Id.");

            try
            {
                var result = await _repo.DeleteCoTravellerAsync(coTravellerId);
                return ApiResponse<int>.SuccessResponse(result, "CoTraveller deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting co-traveller: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<CoTraveller>>> GetAllCoTravellersAsync()
        {
            try
            {
                var result = await _repo.GetAllCoTravellersAsync();
                return ApiResponse<IEnumerable<CoTraveller>>.SuccessResponse(result, "CoTravellers fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CoTraveller>>.FailResponse($"Error fetching co-travellers: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CoTraveller?>> GetCoTravellersByIdAsync(int coTravellerId)
        {
            if (coTravellerId <= 0)
                return ApiResponse<CoTraveller?>.FailResponse("Invalid CoTraveller Id.");

            try
            {
                var result = await _repo.GetCoTravellersByIdAsync(coTravellerId);
                if (result == null)
                    return ApiResponse<CoTraveller?>.FailResponse("CoTraveller not found.");

                return ApiResponse<CoTraveller?>.SuccessResponse(result, "CoTraveller fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<CoTraveller?>.FailResponse($"Error fetching co-traveller: {ex.Message}");
            }
        }
    }
}
