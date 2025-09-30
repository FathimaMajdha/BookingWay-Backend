using BookingApp.Domain.Entities;
using System.Data;
using System.Text.Json;
using Dapper;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTO;
using BookingApp.Application.DTOs;

namespace BookingApp.Infrastructure.Repositories
{
    public class HotelBookingRepository : IHotelBookingRepository
    {
        private readonly IDbConnection _connection;

        public HotelBookingRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddBookingAsync(HotelBookingDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelBooking",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateBookingAsync(int bookingId, VerifyPaymentDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelBooking",
                new { Flag = 2, BookingId = bookingId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteBookingAsync(int bookingId)
        {
            return await _connection.ExecuteAsync(
                "sp_HotelBooking",
                new { Flag = 3, BookingId = bookingId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelBooking>> GetAllBookingsAsync()
        {
            return await _connection.QueryAsync<HotelBooking>(
                "sp_HotelBooking",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelBooking?> GetBookingByIdAsync(int bookingId)
        {
            return await _connection.QueryFirstOrDefaultAsync<HotelBooking>(
                "sp_HotelBooking",
                new { Flag = 5, BookingId = bookingId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
