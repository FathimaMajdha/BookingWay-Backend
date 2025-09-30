using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminFlightRepository : IAdminFlightRepository
    {
        private readonly IDbConnection _connection;

        public AdminFlightRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddFlightSearchAsync(SearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFlightSearch",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateFlightSearchAsync(int flightSearchId, FlightSearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFlightSearch",
                new { Flag = 2, JSON = json, FlightSearchId = flightSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteFlightSearchAsync(int flightSearchId)
        {
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFlightSearch",
                new { Flag = 3, FlightSearchId = flightSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FlightSearch>> GetAllFlightSearchAsync()
        {
            return await _connection.QueryAsync<FlightSearch>(
                "sp_AdminFlightSearch",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<FlightSearch?> GetFlightSearchByIdAsync(int flightSearchId)
        {
            return await _connection.QueryFirstOrDefaultAsync<FlightSearch>(
                "sp_AdminFlightSearch",
                new { Flag = 5, FlightSearchId = flightSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> AddFlightAsync(AdminFlightDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFlight",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateFlightAsync(int flightId, AdminFlightDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFlight",
                new { Flag = 2, JSON = json, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteFlightAsync(int flightId)
        {
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminFlight",
                new { Flag = 3, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AdminFlight>> GetAllFlightsAsync(int? flightSearchId = null)
        {
            return await _connection.QueryAsync<AdminFlight>(
                "sp_AdminFlight",
                new { Flag = 4, FlightSearchId = flightSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminFlight?> GetFlightByIdAsync(int flightId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminFlight>(
                "sp_AdminFlight",
                new { Flag = 5, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
