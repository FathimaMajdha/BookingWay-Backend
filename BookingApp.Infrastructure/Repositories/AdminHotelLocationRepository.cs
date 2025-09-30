using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities;
using BookingApp.Domain.Entities.Admin;
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
    public class AdminHotelLocationRepository : IAdminHotelLocationRepository
    {

        private readonly IDbConnection _connection;

        public AdminHotelLocationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddHotelLocationAsync(AdminHotelLocationDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelLocation",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateHotelLocationAsync(int locationId, AdminHotelLocationDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelLocation",
                new { Flag = 2, LocationId = locationId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteHotelLocationAsync(int locationId)
        {
            return await _connection.ExecuteAsync(
                "sp_AdminHotelLocation",
                new { Flag = 3, LocationId = locationId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AdminHotelLocation>> GetAllHotelLocationAsync()
        {
            return await _connection.QueryAsync<AdminHotelLocation>(
                "sp_AdminHotelLocation",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminHotelLocation> GetHotelLocationByIdAsync(int locationId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminHotelLocation>(
                "sp_AdminHotelLocation",
                new { Flag = 5, LocationId = locationId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
