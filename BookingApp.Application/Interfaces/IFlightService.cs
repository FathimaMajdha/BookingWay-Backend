using BookingApp.Application.Common;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IFlightService
    {
        Task<ApiResponse<int>> AddFlightSearchAsync(SearchDto dto);
        Task<ApiResponse<int>> UpdateFlightSearchAsync(FlightSearchDto dto);
        Task<ApiResponse<int>> DeleteFlightSearchAsync(int flightSearchId);
        Task<ApiResponse<IEnumerable<FlightSearch>>> GetAllFlightSearchAsync();
        Task<ApiResponse<FlightSearch?>> GetFlightSearchByIdAsync(int flightSearchId);
        Task<ApiResponse<int>> AddFlightOfferAsync(FlightOfferDto dto);
        Task<ApiResponse<IEnumerable<FlightOffer>>> GetOffersAsync();
        Task<ApiResponse<IEnumerable<PopularRoute>>> AddPopularRouteAsync(PopularRoutesDto dto);
        Task<ApiResponse<IEnumerable<PopularRoute>>> GetPopularRoutesAsync();
        Task<ApiResponse<IEnumerable<FlightFaq>>> AddFlightFaqAsync(FlightFaqDto dto);
        Task<ApiResponse<IEnumerable<FlightFaq>>> GetFaqsAsync();
        Task<ApiResponse<int>> AddFlightAsync(FlightCreateDto dto);
        Task<ApiResponse<int>> UpdateFlightAsync(int flightId, FlightCreateDto flight);
        Task<ApiResponse<int>> DeleteFlightAsync(int flightId);
        Task<ApiResponse<IEnumerable<Flight>>> GetAllFlightAsync();
        Task<ApiResponse<Flight?>> GetFlightByIdAsync(int flightId);
            
    }

}

