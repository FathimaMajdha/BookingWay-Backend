using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminHotelSearchRepository : IAdminHotelSearchRepository
    {
        private readonly IDbConnection _connection;

        public AdminHotelSearchRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddHotelSearchAsync(AdminHotelSearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelSearch",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateHotelSearchAsync(int hotelSearchId, AdminHotelSearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelSearch",
                new { Flag = 2, JSON = json, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteHotelSearchAsync(int hotelSearchId)
        {
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelSearch",
                new { Flag = 3, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AdminHotelSearch>> GetAllHotelSearchesAsync()
        {
            return await _connection.QueryAsync<AdminHotelSearch>(
                "sp_AdminHotelSearch",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminHotelSearch?> GetHotelSearchByIdAsync(int hotelSearchId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminHotelSearch>(
                "sp_AdminHotelSearch",
                new { Flag = 5, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
