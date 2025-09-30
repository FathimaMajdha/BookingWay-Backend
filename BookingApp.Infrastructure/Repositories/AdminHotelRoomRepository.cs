using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminHotelRoomRepository : IAdminHotelRoomRepository
    {
        private readonly IDbConnection _connection;

        public AdminHotelRoomRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddHotelRoomAsync(AdminHotelRoomDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });

            
            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_AdminHotelRoom",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );

            return result?.InsertedRoomId ?? 0;
        }

        public async Task<int> UpdateHotelRoomAsync(int roomId, AdminHotelRoomDto dto)
        {
            
            var dtoWithId = new
            {
                RoomId = roomId,
                dto.HotelId,
                dto.AmenityId,
                dto.Room_Type,
                dto.Room_Image,
                dto.Price,
                dto.Reviews_Count,
                dto.Reviews_Description,
                dto.Reviewer_Name,
                dto.Review_Date,
                dto.Rating,
                dto.Selectroom_count,
                dto.Available_Rooms,
                dto.MaximumGuest_Count,
                dto.Sqft,
                dto.Bed_Count,
                dto.Bathroom_Count,
                dto.Room_Facility_Description
            };

            var json = JsonSerializer.Serialize(dtoWithId, new JsonSerializerOptions { PropertyNamingPolicy = null });

            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_AdminHotelRoom",
                new { Flag = 2, JSON = json, RoomId = roomId },
                commandType: CommandType.StoredProcedure
            );

            return result?.RowsUpdated ?? 0;
        }

        public async Task<int> DeleteHotelRoomAsync(int roomId)
        {
            
            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_AdminHotelRoom",
                new { Flag = 3, RoomId = roomId },
                commandType: CommandType.StoredProcedure
            );

            return result?.RowsDeleted ?? 0;
        }

        public async Task<IEnumerable<AdminHotelRoom>> GetAllHotelRoomAsync(int? hotelId = null)
        {
            return await _connection.QueryAsync<AdminHotelRoom>(
                "sp_AdminHotelRoom",
                new { Flag = 4, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<AdminHotelRoom?> GetHotelRoomByIdAsync(int roomId)
        {
            return await _connection.QueryFirstOrDefaultAsync<AdminHotelRoom>(
                "sp_AdminHotelRoom",
                new { Flag = 5, RoomId = roomId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}