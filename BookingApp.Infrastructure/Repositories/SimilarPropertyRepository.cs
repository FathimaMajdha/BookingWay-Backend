using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class SimilarPropertyRepository : ISimilarPropertyRepository
    {
        private readonly IDbConnection _connection;

        public SimilarPropertyRepository(IDbConnection connection)
        {
            _connection = connection;
        }

       

        public async Task<int> AddSimilarPropAsync(SimilarPropertyDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_SimilarProperties",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateSimilarPropAsync(int propId, SimilarPropertyDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_SimilarProperties",
                new { Flag = 2, SimilarId = propId, JSON = json }, 
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteSimilarPropAsync(int propId)
        {
            return await _connection.ExecuteAsync(
                "sp_SimilarProperties",
                new { Flag = 3, SimilarId = propId }, 
                commandType: CommandType.StoredProcedure
            );
        }

        

        public async Task<IEnumerable<SimilarProperty>> GetAllSimilarPropAsync()
        {
            return await _connection.QueryAsync<SimilarProperty>(
                "sp_SimilarProperties",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<SimilarProperty> GetSimilarPropByIdAsync(int propId)
        {
            return await _connection.QueryFirstOrDefaultAsync<SimilarProperty>(
                "sp_SimilarProperties",
                new { Flag = 5, SimilarId = propId }, 
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<SimilarPropertyDto>> GetSimilarPropertiesAsync(int hotelId)
        {
            return await _connection.QueryAsync<SimilarPropertyDto>(
                "sp_SimilarProperties",
                new { Flag = 6, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );
        }


    }
}
