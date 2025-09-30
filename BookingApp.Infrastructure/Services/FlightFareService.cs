using BookingApp.Application.Common;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class FlightFareService : IFlightFareService
    {
        private readonly IFlightFareRepository _repository;

        public FlightFareService(IFlightFareRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddfareAsync(FlightFareDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Fare data cannot be null.");

            try
            {
                var result = await _repository.AddFareAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Fare added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding fare: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdatefareAsync(int fareId, FlightFareDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Fare data cannot be null.");

            try
            {
                var result = await _repository.UpdateFareAsync(fareId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Fare updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating fare: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeletefareAsync(int fareId)
        {
            if (fareId <= 0)
                return ApiResponse<int>.FailResponse("Invalid fare Id.");

            try
            {
                var result = await _repository.DeleteFareAsync(fareId);
                return ApiResponse<int>.SuccessResponse(result, "Fare deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting fare: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightFare>>> GetAllfaresAsync()
        {
            try
            {
                var result = await _repository.GetAllFaresAsync();
                return ApiResponse<IEnumerable<FlightFare>>.SuccessResponse(result, "Fares fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightFare>>.FailResponse($"Error fetching fares: {ex.Message}");
            }
        }

        public async Task<ApiResponse<FlightFare?>> GetfareByIdAsync(int fareId)
        {
            if (fareId <= 0)
                return ApiResponse<FlightFare?>.FailResponse("Invalid fare Id.");

            try
            {
                var result = await _repository.GetFareByIdAsync(fareId);
                if (result == null)
                    return ApiResponse<FlightFare?>.FailResponse("Fare not found.");

                return ApiResponse<FlightFare?>.SuccessResponse(result, "Fare fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<FlightFare?>.FailResponse($"Error fetching fare: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightFare>>> GetfaresbyflightAsync(int flightId)
        {
            if (flightId <= 0)
                return ApiResponse<IEnumerable<FlightFare>>.FailResponse("Invalid flight Id.");

            try
            {
                var result = await _repository.GetFaresByFlightIdAsync(flightId);
                return ApiResponse<IEnumerable<FlightFare>>.SuccessResponse(result, "Fares fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightFare>>.FailResponse($"Error fetching fares: {ex.Message}");
            }
        }
    }
}
