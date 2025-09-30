using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class CoTravellerRepository : ICoTravellerRepository
    {
        private readonly IDbConnection _connection;

        public CoTravellerRepository(IDbConnection db)
        {
            _connection = db;
        }

        public async Task<int> AddCoTravellerAsync(int userAuthId, CoTravellerDto traveller)
        {
            var json = JsonSerializer.Serialize(new
            {
                UserAuthId = userAuthId,
                traveller.FirstName,
                traveller.LastName,
                traveller.Gender,
                Date_of_birth = traveller.DateOfBirth,
                traveller.Nationality,
                traveller.Relationship,
                Meal_Preference = traveller.MealPreference,
                Passport_Number = traveller.PassportNumber,
                Expiry_Date = traveller.ExpiryDate,
                Issuing_Country = traveller.IssuingCountry,
                Mobile_Number = traveller.MobileNumber,
                traveller.Email,
                Airline_Name = traveller.AirlineName,
                Frequent_Flight_Number = traveller.FrequentFlightNumber
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Co_Travellers",
                new { Flag = 1, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateCoTravellerAsync(int coTravellerId, CoTravellerDto traveller)
        {
            var json = JsonSerializer.Serialize(new
            {
                traveller.FirstName,
                traveller.LastName,
                traveller.Gender,
                Date_of_birth = traveller.DateOfBirth,
                traveller.Nationality,
                traveller.Relationship,
                Meal_Preference = traveller.MealPreference,
                Passport_Number = traveller.PassportNumber,
                Expiry_Date = traveller.ExpiryDate,
                Issuing_Country = traveller.IssuingCountry,
                Mobile_Number = traveller.MobileNumber,
                traveller.Email,
                Airline_Name = traveller.AirlineName,
                Frequent_Flight_Number = traveller.FrequentFlightNumber
            }, new JsonSerializerOptions { PropertyNamingPolicy = null });

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Co_Travellers",
                new { Flag = 2, CoTravellersId = coTravellerId, JSONDATA = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteCoTravellerAsync(int coTravellerId)
        {
            return await _connection.ExecuteAsync(
                "sp_Co_Travellers",
                new { Flag = 3, CoTravellersId = coTravellerId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<CoTraveller>> GetAllCoTravellersAsync()
        {
            return await _connection.QueryAsync<CoTraveller>(
                "sp_Co_Travellers",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

       
        public async Task<CoTraveller?> GetCoTravellersByIdAsync(int coTravellerId)
        {
            return await _connection.QueryFirstOrDefaultAsync<CoTraveller>(
                "sp_Co_Travellers",
                new { Flag = 5, CoTravellersId = coTravellerId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
