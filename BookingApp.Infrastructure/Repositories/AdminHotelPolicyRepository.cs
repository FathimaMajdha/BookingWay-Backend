using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminHotelPolicyRepository : IAdminHotelPolicyRepository
    {
            private readonly IDbConnection _connection;

            public AdminHotelPolicyRepository(IDbConnection connection)
            {
                _connection = connection;
            }

            public async Task<int> AddHotelPolicyAsync(AdminHotelPolicyDto dto)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
                return await _connection.ExecuteScalarAsync<int>(
                    "sp_AdminHotelPolicies",
                    new { Flag = 1, JSON = json },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<int> UpdateHotelPolicyAsync(int policyId, AdminHotelPolicyDto dto)
            {
                var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
                return await _connection.ExecuteScalarAsync<int>(
                    "sp_AdminHotelPolicies",
                    new { Flag = 2, JSON = json, PolicyId = policyId },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<int> DeleteHotelPolicyAsync(int policyId)
            {
                return await _connection.ExecuteScalarAsync<int>(
                    "sp_AdminHotelPolicies",
                    new { Flag = 3, PolicyId = policyId },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<IEnumerable<AdminHotelPolicy>> GetAllHotelPolicyAsync(int? hotelId = null)
            {
                return await _connection.QueryAsync<AdminHotelPolicy>(
                    "sp_AdminHotelPolicies",
                    new { Flag = 4, HotelId = hotelId },
                    commandType: CommandType.StoredProcedure
                );
            }

            public async Task<AdminHotelPolicy?> GetHotelPolicyByIdAsync(int policyId)
            {
                return await _connection.QueryFirstOrDefaultAsync<AdminHotelPolicy>(
                    "sp_AdminHotelPolicies",
                    new { Flag = 5, PolicyId = policyId },
                    commandType: CommandType.StoredProcedure
                );
            }

     }

}

