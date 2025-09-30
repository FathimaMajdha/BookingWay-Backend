using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IFlightRepository
    {
       

        Task<int> SaveSearchAsync(SearchDto dto);
        Task<int> UpdateSearchAsync(FlightSearchDto dto);
        Task<int> DeleteSearchAsync(int flightSearchId);

        Task<IEnumerable<FlightSearch>> GetAllFlightSearchAsync();


        Task<FlightSearch> GetFlightSearchByIdAsync(int flightSearchId);
       
        Task<int> AddFlightOfferAsync(FlightOfferDto dto);
        Task<IEnumerable<FlightOffer>> GetOffersAsync();



        Task<IEnumerable<PopularRoute>> AddPopularRoutesAsync(PopularRoutesDto dto);
        Task<IEnumerable<PopularRoute>> GetPopularRoutesAsync();


        Task<IEnumerable<FlightFaq>> AddFlightFaqAsync(FlightFaqDto dto);
        Task<IEnumerable<FlightFaq>> GetFaqsAsync();


        Task<int> AddAsync(FlightCreateDto flight);
        Task<int> UpdateAsync(int flightId, FlightCreateDto flight);
        Task<int> DeleteAsync(int flightId);
        Task<IEnumerable<Flight>> GetAllFlightAsync();
        Task<Flight> GetFlightByIdAsync(int flightId);
       
    }

}

