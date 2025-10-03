using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminSimilarPropertyRepository : IAdminSimilarPropertyRepository
    {
        private readonly IDbConnection _connection;

        public AdminSimilarPropertyRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddSimilarPropAsync(AdminSimilarPropertyDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminSimilarProperties",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateSimilarPropAsync(int propId, AdminSimilarPropertyDto dto)
        {
            var dtoWithoutId = new
            {
                dto.HotelId,
                dto.SimilarHotel_Name,
                dto.Location,
                dto.Reviews,
                dto.Rating,
                dto.Price_Per_Night,
                dto.ImageUrl
            };

            var json = JsonSerializer.Serialize(dtoWithoutId, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminSimilarProperties",
                new { Flag = 2, SimilarId = propId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteSimilarPropAsync(int propId)
        {
            return await _connection.ExecuteAsync(
                "sp_AdminSimilarProperties",
                new { Flag = 3, SimilarId = propId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AdminSimilarProperty>> GetAllSimilarPropAsync()
        {
            return await _connection.QueryAsync<AdminSimilarProperty>(
                "sp_AdminSimilarProperties",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminSimilarProperty> GetSimilarPropByIdAsync(int propId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminSimilarProperty>(
                "sp_AdminSimilarProperties",
                new { Flag = 5, SimilarId = propId },
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task<IEnumerable<AdminSimilarPropertyDto>> GetSimilarPropertiesAsync(int hotelId)
        {
            return await _connection.QueryAsync<AdminSimilarPropertyDto>(
                "sp_AdminSimilarProperties",
                new { Flag = 6, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}