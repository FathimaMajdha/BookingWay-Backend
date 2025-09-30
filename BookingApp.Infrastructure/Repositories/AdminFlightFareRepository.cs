using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminFlightFareRepository : IAdminFlightFareRepository
    {
        private readonly IDbConnection _connection;

        public AdminFlightFareRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddFlightFareAsync(AdminFlightFareDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFareModal",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateFlightFareAsync(int fareId, AdminFlightFareDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFareModal",
                new { Flag = 2, JSON = json, FareId = fareId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteFlightFareAsync(int fareId)
        {
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFareModal",
                new { Flag = 3, FareId = fareId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AdminFlightFare>> GetAllFlightFaresAsync(int? flightId = null)
        {
            return await _connection.QueryAsync<AdminFlightFare>(
                "sp_AdminFareModal",
                new { Flag = 4, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminFlightFare?> GetFlightFareByIdAsync(int fareId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminFlightFare>(
                "sp_AdminFareModal",
                new { Flag = 5, FareId = fareId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}