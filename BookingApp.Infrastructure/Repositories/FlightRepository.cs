using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbConnection _connection;

        public FlightRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #region Flight Search

       
        public async Task<int> SaveSearchAsync(SearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Flight_Search",
                new { Flag = 1, JSONDATA = json }, 
                commandType: CommandType.StoredProcedure
            );
        }

       
        public async Task<int> UpdateSearchAsync(FlightSearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Flight_Search",
                new { Flag = 2, JSONDATA = json }, 
                commandType: CommandType.StoredProcedure
            );
        }

       
        public async Task<int> DeleteSearchAsync(int flightSearchId)
        {
            return await _connection.ExecuteAsync(
                "sp_Flight_Search",
                new { Flag = 3, FlightSearchId = flightSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task<IEnumerable<FlightSearch>> GetAllFlightSearchAsync()
        {
            return await _connection.QueryAsync<FlightSearch>(
                "sp_Flight_Search",
                new { Flag = 4 }, 
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task<FlightSearch> GetFlightSearchByIdAsync(int flightSearchId)
        {
            return await _connection.QueryFirstOrDefaultAsync<FlightSearch>(
                "sp_Flight_Search",
                new { Flag = 5, FlightSearchId = flightSearchId }, 
                commandType: CommandType.StoredProcedure
            );
        }
        #endregion


        #region Flight Offers

        public async Task<int> AddFlightOfferAsync(FlightOfferDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.Flight_Name,
                dto.Flight_Image,
                dto.FlightOffer_Description,
                dto.DiscountPercentage,
                dto.Valid_Date
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_FlightOffer",
                new { Flag = 1, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public Task<IEnumerable<FlightOffer>> GetOffersAsync() =>
            _connection.QueryAsync<FlightOffer>(
                "sp_FlightOffer",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );

        #endregion

        #region Popular Routes

        public async Task<IEnumerable<PopularRoute>> AddPopularRoutesAsync(PopularRoutesDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.RouteFlight_Name,
                dto.Route_From
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.QueryAsync<PopularRoute>(
                "sp_Popular_Flight_Routes",
                new { Flag = 1, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public Task<IEnumerable<PopularRoute>> GetPopularRoutesAsync() =>
            _connection.QueryAsync<PopularRoute>(
                "sp_Popular_Flight_Routes",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );

        #endregion

        #region FAQs

        public async Task<IEnumerable<FlightFaq>> AddFlightFaqAsync(FlightFaqDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.Question,
                dto.Answer
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.QueryAsync<FlightFaq>(
                "sp_FlightBooking_Faqs",
                new { Flag = 1, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public Task<IEnumerable<FlightFaq>> GetFaqsAsync() =>
            _connection.QueryAsync<FlightFaq>(
                "sp_FlightBooking_Faqs",
                new { Flag = 2 },
                commandType: CommandType.StoredProcedure
            );

        #endregion

        #region Flights CRUD


       
        public async Task<int> AddAsync(FlightCreateDto flight)
        {
            var json = JsonSerializer.Serialize(new
            {
                flight.FlightSearchId,
                flight.Passenger_Count,
                flight.Passenger_Type,
                flight.Airline_Name,
                flight.Airline_Icon,
                flight.IATA_Code,
                flight.FlightNumber,
                flight.Aircraft_Type,
                flight.Depart_DateTime,
                flight.Depart_Place,
                flight.Depart_Duration,
                flight.Terminal,
                flight.Baggage,
                flight.Checkin,
                flight.CABIN,
                flight.Arrival_DateTime,
                flight.Arrival_Place,
                flight.Return_Depart_DateTime,
                flight.Return_Depart_Place,
                flight.Return_Duration,
                flight.Return_Arrival_DateTime,
                flight.Return_Arrival_Place,
                flight.Base_Fare,
                flight.Currency,
                flight.IsRefundable,
                flight.Stops,
                flight.TravelClass
    }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Flight",
                new { Flag = 1, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateAsync(int flightId, FlightCreateDto flight)
        {
            var json = JsonSerializer.Serialize(flight, new JsonSerializerOptions { PropertyNamingPolicy = null });

            var updatedId = await _connection.ExecuteScalarAsync<int>(
                "sp_Flight",
                new { Flag = 2, FlightId = flightId, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );

            return updatedId; 
        }


        public async Task<int> DeleteAsync(int flightId)
        {
            var rows = await _connection.ExecuteAsync(
                "sp_Flight",
                new { Flag = 3, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );

            return rows; 
        }

        public async Task<IEnumerable<Flight>> GetAllFlightAsync()
        {
            return await _connection.QueryAsync<Flight>(
                "sp_Flight",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            return await _connection.QueryFirstOrDefaultAsync<Flight>(
                "sp_Flight",
                new { Flag = 5, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion
    }
}
