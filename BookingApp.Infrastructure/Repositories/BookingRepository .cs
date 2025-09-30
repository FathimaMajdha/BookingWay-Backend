using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
                new { UserAuthId = userAuthId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
