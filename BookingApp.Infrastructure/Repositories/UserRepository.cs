using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BookingApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection db)
        {
            _connection = db;
        }

        public async Task<UserAuth?> GetByLoginAsync(string username, string password)
        {
            try
            {
                var result = await _connection.QueryFirstOrDefaultAsync<UserAuth>(
                    "sp_Login",
                    new { Username = username, Password = password },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByLoginAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<UserAuth?> RegisterUserAsync(UserAuth user)
        {
            try
            {
                var result = await _connection.QueryFirstOrDefaultAsync<UserAuth>(
                    "sp_Register",
                    new { user.Username, user.Password, user.Email, user.Role },
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in RegisterUserAsync: {ex.Message}");
                throw;
            }
        }


    }

}
