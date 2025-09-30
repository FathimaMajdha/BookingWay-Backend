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
    public class HotelLocationRepository :IHotelLocationRepository
    {
        private readonly IDbConnection _connection;

        public HotelLocationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddLocationAsync(CreateHotelLocationDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelLocation",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateLocationAsync(int locationId, CreateHotelLocationDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelLocation",
                new { Flag = 2, LocationId=locationId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteLocationAsync(int locationId)
        {
            return await _connection.ExecuteAsync(
                "sp_HotelLocation",
                new { Flag = 3, LocationId=locationId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelLocation>> GetAllLocationAsync()
        {
            return await _connection.QueryAsync<HotelLocation>(
                "sp_HotelLocation",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelLocation> GetLocationByIdAsync(int locationId)
        {
            return await _connection.QueryFirstOrDefaultAsync<HotelLocation>(
                "sp_HotelLocation",
                new { Flag = 5, LocationId = locationId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
