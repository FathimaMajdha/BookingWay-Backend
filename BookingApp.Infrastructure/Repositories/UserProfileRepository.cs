using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly IDbConnection _connection;

    public UserProfileRepository(IDbConnection db)
    {
        _connection = db;
    }

    #region Add User
    public async Task<int> AddUserAsync(int userAuthId, UserProfileDto user)
    {
        try
        {
            var json = JsonSerializer.Serialize(new
            {
                UserAuthId = userAuthId,
                user.FirstName,
                user.LastName,
                user.Gender,
                user.UserImage,
                user.DateOfBirth,
                user.Nationality,
                user.MaritalStatus,
                user.City,
                user.State,
                user.MobileNumber,
                user.PassportNumber,
                user.ExpiryDate,
                user.IssuingCountry,
                user.PancardNumber,
                user.AirlineName,
                user.FrequentFlightNumber
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Users",
                new { Flag = 1, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in AddUserAsync: {ex.Message}");
            throw;
        }
    }
    #endregion

    #region Update User
    public async Task<int> UpdateUserAsync(int userId, UserProfileDto user)
    {
        try
        {
            var json = JsonSerializer.Serialize(new
            {
                user.FirstName,
                user.LastName,
                user.Gender,
                user.UserImage,
                user.DateOfBirth,
                user.Nationality,
                user.MaritalStatus,
                user.City,
                user.State,
                user.MobileNumber,
                user.PassportNumber,
                user.ExpiryDate,
                user.IssuingCountry,
                user.PancardNumber,
                user.AirlineName,
                user.FrequentFlightNumber
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Users",
                new { Flag = 2, UserId = userId, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UpdateUserAsync: {ex.Message}");
            throw;
        }
    }
    #endregion

    

    #region Delete User
    public async Task<int> DeleteUserAsync(int userAuthId)
    {
        var rows = await _connection.ExecuteAsync(
            "sp_Users",
            new { Flag = 3, UserAuthId = userAuthId },
            commandType: CommandType.StoredProcedure
        );

        return rows; 
    }
    #endregion



    #region Get All Users
    public async Task<IEnumerable<UserProfile>> GetAllAsync()
    {
        try
        {
            return await _connection.QueryAsync<UserProfile>(
                "sp_Users",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetAllAsync: {ex.Message}");
            throw;
        }
    }
    #endregion

    #region Get User By Id
   
    public async Task<UserProfile?> GetByAuthIdAsync(int userAuthId)
    {
        try
        {
            return await _connection.QueryFirstOrDefaultAsync<UserProfile>(
                "sp_Users",
                new { Flag = 5, UserAuthId = userAuthId },
                commandType: CommandType.StoredProcedure
            );
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetByAuthIdAsync Repository: {ex.Message}");
            throw;
        }
    }

    #endregion
}
