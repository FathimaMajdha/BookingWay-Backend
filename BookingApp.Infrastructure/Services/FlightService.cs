using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _repo;

        public FlightService(IFlightRepository repo)
        {
            _repo = repo;
        }

        
        public async Task<ApiResponse<int>> AddFlightSearchAsync(SearchDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Search data cannot be null.");

            try
            {
                var result = await _repo.SaveSearchAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight search added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding flight search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateFlightSearchAsync(FlightSearchDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Search data cannot be null.");

            try
            {
                var result = await _repo.UpdateSearchAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight search updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating flight search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteFlightSearchAsync(int flightSearchId)
        {
            if (flightSearchId <= 0)
                return ApiResponse<int>.FailResponse("Invalid flight search Id.");

            try
            {
                var result = await _repo.DeleteSearchAsync(flightSearchId);
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
                var result = await _repo.GetAllFlightSearchAsync();
                return ApiResponse<IEnumerable<FlightSearch>>.SuccessResponse(result, "Flight searches fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightSearch>>.FailResponse($"Error fetching flight searches: {ex.Message}");
            }
        }

        public async Task<ApiResponse<FlightSearch?>> GetFlightSearchByIdAsync(int flightSearchId)
        {
            if (flightSearchId <= 0)
                return ApiResponse<FlightSearch?>.FailResponse("Invalid flight search Id.");

            try
            {
                var result = await _repo.GetFlightSearchByIdAsync(flightSearchId);
                if (result == null)
                    return ApiResponse<FlightSearch?>.FailResponse("Flight search not found.");

                return ApiResponse<FlightSearch?>.SuccessResponse(result, "Flight search fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<FlightSearch?>.FailResponse($"Error fetching flight search: {ex.Message}");
            }
        }

        
        public async Task<ApiResponse<int>> AddFlightOfferAsync(FlightOfferDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Offer data cannot be null.");

            try
            {
                var result = await _repo.AddFlightOfferAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight offer added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding flight offer: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightOffer>>> GetOffersAsync()
        {
            try
            {
                var result = await _repo.GetOffersAsync();
                return ApiResponse<IEnumerable<FlightOffer>>.SuccessResponse(result, "Flight offers fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightOffer>>.FailResponse($"Error fetching flight offers: {ex.Message}");
            }
        }

        
        public async Task<ApiResponse<IEnumerable<PopularRoute>>> AddPopularRouteAsync(PopularRoutesDto dto)
        {
            if (dto == null)
                return ApiResponse<IEnumerable<PopularRoute>>.FailResponse("Route data cannot be null.");

            try
            {
                var result = await _repo.AddPopularRoutesAsync(dto);
                return ApiResponse<IEnumerable<PopularRoute>>.SuccessResponse(result, "Popular route added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<PopularRoute>>.FailResponse($"Error adding popular route: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<PopularRoute>>> GetPopularRoutesAsync()
        {
            try
            {
                var result = await _repo.GetPopularRoutesAsync();
                return ApiResponse<IEnumerable<PopularRoute>>.SuccessResponse(result, "Popular routes fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<PopularRoute>>.FailResponse($"Error fetching popular routes: {ex.Message}");
            }
        }

       
        public async Task<ApiResponse<IEnumerable<FlightFaq>>> AddFlightFaqAsync(FlightFaqDto dto)
        {
            if (dto == null)
                return ApiResponse<IEnumerable<FlightFaq>>.FailResponse("FAQ data cannot be null.");

            try
            {
                var result = await _repo.AddFlightFaqAsync(dto);
                return ApiResponse<IEnumerable<FlightFaq>>.SuccessResponse(result, "Flight FAQ added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightFaq>>.FailResponse($"Error adding flight FAQ: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<FlightFaq>>> GetFaqsAsync()
        {
            try
            {
                var result = await _repo.GetFaqsAsync();
                return ApiResponse<IEnumerable<FlightFaq>>.SuccessResponse(result, "Flight FAQs fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<FlightFaq>>.FailResponse($"Error fetching flight FAQs: {ex.Message}");
            }
        }

       
        public async Task<ApiResponse<int>> AddFlightAsync(FlightCreateDto dto)
        {
            if (dto == null)
                return ApiResponse<int>.FailResponse("Flight data cannot be null.");

            try
            {
                var result = await _repo.AddAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Flight added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding flight: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateFlightAsync(int flightId, FlightCreateDto flight)
        {
            if (flight == null)
                return ApiResponse<int>.FailResponse("Flight data cannot be null.");

            try
            {
                var result = await _repo.UpdateAsync(flightId, flight);
                return ApiResponse<int>.SuccessResponse(result, "Flight updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating flight: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteFlightAsync(int flightId)
        {
            if (flightId <= 0)
                return ApiResponse<int>.FailResponse("Invalid flight Id.");

            try
            {
                var result = await _repo.DeleteAsync(flightId);
                return ApiResponse<int>.SuccessResponse(result, "Flight deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting flight: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Flight>>> GetAllFlightAsync()
        {
            try
            {
                var result = await _repo.GetAllFlightAsync();
                return ApiResponse<IEnumerable<Flight>>.SuccessResponse(result, "Flights fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Flight>>.FailResponse($"Error fetching flights: {ex.Message}");
            }
        }

        public async Task<ApiResponse<Flight?>> GetFlightByIdAsync(int flightId)
        {
            if (flightId <= 0)
                return ApiResponse<Flight?>.FailResponse("Invalid flight Id.");

            try
            {
                var result = await _repo.GetFlightByIdAsync(flightId);
                if (result == null)
                    return ApiResponse<Flight?>.FailResponse("Flight not found.");

                return ApiResponse<Flight?>.SuccessResponse(result, "Flight fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<Flight?>.FailResponse($"Error fetching flight: {ex.Message}");
            }
        }
    }
}
