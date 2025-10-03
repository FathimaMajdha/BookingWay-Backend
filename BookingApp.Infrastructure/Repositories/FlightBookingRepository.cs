using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
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
    public class FlightBookingRepository : IFlightBookingRepository
    {
        private readonly IDbConnection _connection;

        public FlightBookingRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddBookingAsync(FlightBookingDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_FlightBooking",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateBookingAsync(int bookingId, RazorpayVerificationRequest dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_FlightBooking",
                new { Flag = 2, BookingId = bookingId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteBookingAsync(int bookingId)
        {
            return await _connection.ExecuteAsync(
                "sp_FlightBooking",
                new { Flag = 3, BookingId = bookingId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FlightBooking>> GetAllBookingsAsync()
        {
            return await _connection.QueryAsync<FlightBooking>(
                "sp_FlightBooking",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<FlightBooking?> GetBookingByIdAsync(int bookingId)
        {
            return await _connection.QueryFirstOrDefaultAsync<FlightBooking>(
                "sp_FlightBooking",
                new { Flag = 5, BookingId = bookingId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<FlightBooking>> GetBookingsByFlightIdAsync(int flightId)
        {
            return await _connection.QueryAsync<FlightBooking>(
                "sp_FlightBooking",
                new { Flag = 6, FlightId = flightId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
