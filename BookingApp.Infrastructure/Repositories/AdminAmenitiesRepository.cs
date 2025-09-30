using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;
namespace BookingApp.Infrastructure.Repositories
{
    public class AdminAmenitiesRepository : IAdminAmenitiesRepository
    {
            private readonly IDbConnection _connection;

            public AdminAmenitiesRepository(IDbConnection connection)
            {
                _connection = connection;
            }

            public async Task<int> AddHotelAmenityAsync(AdminAmenityDto dto)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
                return await _connection.ExecuteScalarAsync<int>(
                    "sp_AdminAmenities",
                    new { Flag = 1, JSON = json },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<int> UpdateHotelAmenityAsync(int amenityId, AdminAmenityDto dto)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
                return await _connection.ExecuteScalarAsync<int>(
                    "sp_AdminAmenities",
                    new { Flag = 2, JSON = json, AmenityId = amenityId },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<int> DeleteHotelAmenityAsync(int amenityId)
            {
                return await _connection.ExecuteScalarAsync<int>(
                    "sp_AdminAmenities",
                    new { Flag = 3, AmenityId = amenityId },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<IEnumerable<AdminAmenity>> GetAllHotelAmenityAsync(int? hotelId = null)
            {
                return await _connection.QueryAsync<AdminAmenity>(
                    "sp_AdminAmenities",
                    new { Flag = 4, HotelId = hotelId },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<AdminAmenity?> GetHotelAmenityByIdAsync(int amenityId)
            {
                return await _connection.QueryFirstOrDefaultAsync<AdminAmenity>(
                    "sp_AdminAmenities",
                    new { Flag = 5, AmenityId = amenityId },
                    commandType: CommandType.StoredProcedure
                );
            }
        
    }

}

