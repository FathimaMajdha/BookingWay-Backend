using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbConnection _connection;

        public BookingRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<MyBookingDto>> GetMyBookingsAsync(int userAuthId)
        {
            return await _connection.QueryAsync<MyBookingDto>(
                "sp_My_Booking",
                new { Flag = 1, UserAuthId = userAuthId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<MyBookingDto>> GetMyFlightBookingsAsync(int userAuthId)
        {
            return await _connection.QueryAsync<MyBookingDto>(
                "sp_My_Booking",
                new { Flag = 2, UserAuthId = userAuthId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<MyBookingDto>> GetMyHotelBookingsAsync(int userAuthId)
        {
            return await _connection.QueryAsync<MyBookingDto>(
                "sp_My_Booking",
                new { Flag = 3, UserAuthId = userAuthId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteBookingAsync(int myBookingId, int userAuthId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<int>(
                "sp_My_Booking",
                new { Flag = 4, MyBookingId = myBookingId, UserAuthId = userAuthId },
                commandType: CommandType.StoredProcedure
            );

            return result; 
        }
    }
}