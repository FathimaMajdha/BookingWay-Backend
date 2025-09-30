using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Repositories
{
    public class FlightFareRepository : IFlightFareRepository
    {

        private readonly IDbConnection _connection;

        public FlightFareRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddFareAsync(FlightFareDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Flight_Fare",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }



        public async Task<int> UpdateFareAsync(int fareId, FlightFareDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Flight_Fare",
                new { Flag = 2, FareId = fareId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteFareAsync(int fareId)
        {
            return await _connection.ExecuteAsync(
                "sp_Flight_Fare",
                new { Flag = 3, FareId = fareId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FlightFare>> GetAllFaresAsync()
        {
            return await _connection.QueryAsync<FlightFare>(
                "sp_Flight_Fare",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<FlightFare?> GetFareByIdAsync(int fareId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<FlightFare>(
                "sp_Flight_Fare",
                new { Flag = 5, FareId = fareId },
                commandType: CommandType.StoredProcedure
            );

            return result; 
        }

        public async Task<IEnumerable<FlightFare>> GetFaresByFlightIdAsync(int flightId)
        {
            var result = await _connection.QueryAsync<FlightFare>(
                "sp_Flight_Fare",
                new { Flag = 6, FareId = flightId }, 
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

    }
}
