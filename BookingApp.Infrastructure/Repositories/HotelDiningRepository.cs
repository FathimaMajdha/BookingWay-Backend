using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class HotelDiningRepository : IHotelDiningRepository
    {
        private readonly IDbConnection _connection;

        public HotelDiningRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        
        
        public async Task<int> AddDiningAsync(HotelDiningDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Hotel_Dining",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

       
        public async Task<int> UpdateDiningAsync(int diningId, HotelDiningDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Hotel_Dining",
                new { Flag = 2, DiningId = diningId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

       
        public async Task<int> DeleteDiningAsync(int diningId)
        {
            return await _connection.ExecuteAsync(
                "sp_Hotel_Dining",
                new { Flag = 3, DiningId = diningId },
                commandType: CommandType.StoredProcedure
            );
        }

        
        public async Task<IEnumerable<HotelDining>> GetAllDiningAsync()
        {
            return await _connection.QueryAsync<HotelDining>(
                "sp_Hotel_Dining",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

       
        public async Task<HotelDining> GetDiningByIdAsync(int diningId)
        {
            return await _connection.QueryFirstOrDefaultAsync<HotelDining>(
                "sp_Hotel_Dining",
                new { Flag = 5, DiningId = diningId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
