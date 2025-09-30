using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminBookingRepository : IAdminBookingRepository
    {
        private readonly IConfiguration _configuration;

        public AdminBookingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<AdminBooking>> GetAllAdminBookingsAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var result = await connection.QueryAsync<AdminBooking>(
                "sp_AdminBooking",
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
    }
}
