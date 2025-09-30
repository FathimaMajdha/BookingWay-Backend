using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminFlightFareService : IAdminFlightFareService
        {
            private readonly IAdminFlightFareRepository _flightFareRepository;

            public AdminFlightFareService(IAdminFlightFareRepository flightFareRepository)
            {
                _flightFareRepository = flightFareRepository;
            }

            public async Task<ApiResponse<int>> AddFlightFareAsync(AdminFlightFareDto dto)
            {
                try
                {
                    var result = await _flightFareRepository.AddFlightFareAsync(dto);
                    return ApiResponse<int>.SuccessResponse(result, "Flight fare added successfully");
                }
                catch (Exception ex)
                {
                    return ApiResponse<int>.FailResponse($"Error adding flight fare: {ex.Message}");
                }
            }

            public async Task<ApiResponse<int>> UpdateFlightFareAsync(int fareId, AdminFlightFareDto dto)
            {
                try
                {
                    var result = await _flightFareRepository.UpdateFlightFareAsync(fareId, dto);
                    if (result > 0)
                        return ApiResponse<int>.SuccessResponse(result, "Flight fare updated successfully");
                    else
                        return ApiResponse<int>.FailResponse("Flight fare not found or no changes made");
                }
                catch (Exception ex)
                {
                    return ApiResponse<int>.FailResponse($"Error updating flight fare: {ex.Message}");
                }
            }

            public async Task<ApiResponse<int>> DeleteFlightFareAsync(int fareId)
            {
                try
                {
                    var result = await _flightFareRepository.DeleteFlightFareAsync(fareId);
                    if (result > 0)
                        return ApiResponse<int>.SuccessResponse(result, "Flight fare deleted successfully");
                    else
                        return ApiResponse<int>.FailResponse("Flight fare not found");
                }
                catch (Exception ex)
                {
                    return ApiResponse<int>.FailResponse($"Error deleting flight fare: {ex.Message}");
                }
            }

            public async Task<ApiResponse<IEnumerable<AdminFlightFare>>> GetAllFlightFaresAsync(int? flightId = null)
            {
                try
                {
                    var fares = await _flightFareRepository.GetAllFlightFaresAsync(flightId);
                    return ApiResponse<IEnumerable<AdminFlightFare>>.SuccessResponse(fares, "Flight fares retrieved successfully");
                }
                catch (Exception ex)
                {
                    return ApiResponse<IEnumerable<AdminFlightFare>>.FailResponse($"Error retrieving flight fares: {ex.Message}");
                }
            }

            public async Task<ApiResponse<AdminFlightFare?>> GetFlightFareByIdAsync(int fareId)
            {
                try
                {
                    var fare = await _flightFareRepository.GetFlightFareByIdAsync(fareId);
                    if (fare != null)
                        return ApiResponse<AdminFlightFare?>.SuccessResponse(fare, "Flight fare retrieved successfully");
                    else
                        return ApiResponse<AdminFlightFare?>.FailResponse("Flight fare not found");
                }
                catch (Exception ex)
                {
                    return ApiResponse<AdminFlightFare?>.FailResponse($"Error retrieving flight fare: {ex.Message}");
                }
            }
        
    }
}

