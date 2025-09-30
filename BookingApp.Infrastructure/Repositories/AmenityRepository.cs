using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly IDbConnection _connection;

        public AmenityRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddAmenityAsync(AmenityDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Amenities",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }


       
        public async Task<int> UpdateAmenityAsync(int amenityId,AmenityDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Amenities",
                new { Flag = 2,AmenityId=amenityId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteAmenityAsync(int amenityId)
        {
            return await _connection.ExecuteAsync(
                "sp_Amenities",
                new { Flag = 3, AmenityId = amenityId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Amenity>> GetAllAmenitiesAsync()
        {
            return await _connection.QueryAsync<Amenity>(
                "sp_Amenities",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Amenity> GetAmenityByIdAsync(int amenityId)
        {
            return await _connection.QueryFirstOrDefaultAsync<Amenity>(
                "sp_Amenities",
                new { Flag = 5, AmenityId = amenityId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
