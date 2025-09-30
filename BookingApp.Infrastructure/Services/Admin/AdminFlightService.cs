using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminFlightService : IAdminFlightService
    {
        private readonly IAdminFlightRepository _repository;

        public AdminFlightService(IAdminFlightRepository repository)
        {
            _repository = repository;
        }

        
        public async Task<ApiResponse<int>> AddFlightSearchAsync(SearchDto dto)
        {
            try
            {
                var result = await _repository.AddFlightSearchAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight search added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding flight search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateFlightSearchAsync(int flightSearchId, FlightSearchDto dto)
        {
            try
            {
                var result = await _repository.UpdateFlightSearchAsync(flightSearchId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight search updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating flight search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteFlightSearchAsync(int flightSearchId)
        {
            try
            {
                var result = await _repository.DeleteFlightSearchAsync(flightSearchId);
                return ApiResponse<int>.SuccessResponse(result, "Flight search deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting flight search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightSearch>>> GetAllFlightSearchAsync()
        {
            try
            {
                var result = await _repository.GetAllFlightSearchAsync();
                return ApiResponse<IEnumerable<FlightSearch>>.SuccessResponse(result, "Flight searches fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightSearch>>.FailResponse($"Error fetching flight searches: {ex.Message}");
            }
        }

        public async Task<ApiResponse<FlightSearch?>> GetFlightSearchByIdAsync(int flightSearchId)
        {
            try
            {
                var result = await _repository.GetFlightSearchByIdAsync(flightSearchId);
                if (result == null)
                    return ApiResponse<FlightSearch?>.FailResponse("Flight search not found.");

                return ApiResponse<FlightSearch?>.SuccessResponse(result, "Flight search fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<FlightSearch?>.FailResponse($"Error fetching flight search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> AddFlightAsync(AdminFlightDto dto)
        {
            try
            {
                var result = await _repository.AddFlightAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding flight: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateFlightAsync(int flightId, AdminFlightDto dto)
        {
            try
            {
                var result = await _repository.UpdateFlightAsync(flightId, dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating flight: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteFlightAsync(int flightId)
        {
            try
            {
                var result = await _repository.DeleteFlightAsync(flightId);
                return ApiResponse<int>.SuccessResponse(result, "Flight deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting flight: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminFlight>>> GetAllFlightsAsync(int? flightSearchId = null)
        {
            try
            {
                var result = await _repository.GetAllFlightsAsync(flightSearchId);
                return ApiResponse<IEnumerable<AdminFlight>>.SuccessResponse(result, "Flights fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminFlight>>.FailResponse($"Error fetching flights: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminFlight?>> GetFlightByIdAsync(int flightId)
        {
            try
            {
                var result = await _repository.GetFlightByIdAsync(flightId);
                if (result == null)
                    return ApiResponse<AdminFlight?>.FailResponse("Flight not found.");

                return ApiResponse<AdminFlight?>.SuccessResponse(result, "Flight fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminFlight?>.FailResponse($"Error fetching flight: {ex.Message}");
            }
        }
    }
}
