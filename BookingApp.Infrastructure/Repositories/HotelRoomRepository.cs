using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly IDbConnection _connection;

        public HotelRoomRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddRoomAsync(HotelRoomDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Hotel_Room",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelRoomDto> UpdateRoomAsync(int roomId, HotelRoomDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.QueryFirstOrDefaultAsync<HotelRoomDto>(
                "sp_Hotel_Room",
                new { Flag = 3, JSON = json, RoomId = roomId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteRoomAsync(int roomId)
        {
            return await _connection.ExecuteAsync(
                "sp_Hotel_Room",
                new { Flag = 4, RoomId = roomId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelRoom>> GetAllRoomsAsync()
        {
            return await _connection.QueryAsync<HotelRoom>(
                "sp_Hotel_Room",
                new { Flag = 5 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelRoom> GetRoomByIdAsync(int roomId)
        {
            return await _connection.QueryFirstOrDefaultAsync<HotelRoom>(
                "sp_Hotel_Room",
                new { Flag = 6, RoomId = roomId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
