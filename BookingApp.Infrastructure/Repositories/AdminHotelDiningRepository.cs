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
    public class AdminHotelDiningRepository :IAdminHotelDiningRepository
    {

        private readonly IDbConnection _connection;

        public AdminHotelDiningRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<int> AddDiningAsync(AdminHotelDiningDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelDining",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<int> UpdateDiningAsync(int diningId, AdminHotelDiningDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotelDining",
                new { Flag = 2, DiningId = diningId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<int> DeleteDiningAsync(int diningId)
        {
            return await _connection.ExecuteAsync(
                "sp_AdminHotelDining",
                new { Flag = 3, DiningId = diningId },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<IEnumerable<AdminHotelDining>> GetAllDiningAsync()
        {
            return await _connection.QueryAsync<AdminHotelDining>(
                "sp_AdminHotelDining",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<AdminHotelDining> GetDiningByIdAsync(int diningId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminHotelDining>(
                "sp_AdminHotelDining",
                new { Flag = 5, DiningId = diningId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
