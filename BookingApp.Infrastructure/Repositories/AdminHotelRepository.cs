using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminHotelRepository : IAdminHotelRepository
    {
        private readonly IDbConnection _connection;

        public AdminHotelRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddHotelAsync(AdminHotelDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions
            {
                PropertyNamingPolicy = null,
                WriteIndented = false
            });

            var result = await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotel",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<int> UpdateHotelAsync(int hotelId, AdminHotelDto dto)
        {
           
            var dtoWithId = new
            {
                HotelId = hotelId,
                dto.Hotel_Search_Id,
                dto.Hotel_Name,
                dto.Nearest_Location,
                dto.City,
                dto.Rating,
                dto.Hotel_Description,
                dto.Price,
                dto.Reviews,
                dto.FreeCancellation,
                dto.BreakfastIncluded,
                dto.AmenitiesDescription,
                dto.Hotel_Pictures
            };

            var json = JsonSerializer.Serialize(dtoWithId, new JsonSerializerOptions
            {
                PropertyNamingPolicy = null,
                WriteIndented = false
            });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotel",
                new { Flag = 2, JSON = json, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteHotelAsync(int hotelId)
        {
            return await _connection.ExecuteScalarAsync<int>(
                "sp_AdminHotel",
                new { Flag = 3, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<AdminHotel>> GetAllHotelsAsync(int? hotelSearchId = null)
        {
            return await _connection.QueryAsync<AdminHotel>(
                "sp_AdminHotel",
                new { Flag = 4, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminHotel?> GetHotelByIdAsync(int hotelId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminHotel>(
                "sp_AdminHotel",
                new { Flag = 5, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}