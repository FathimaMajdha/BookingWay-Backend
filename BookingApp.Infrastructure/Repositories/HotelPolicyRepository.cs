using BookingApp.Application.DTOs.HotelPropertyDto;
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
    public class HotelPolicyRepository: IHotelPolicyRepository
    {
        private readonly IDbConnection _connection;

        public HotelPolicyRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddpolicyAsync(CreateHotelPolicyDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelPolicies",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdatePolicyAsync(int policyId, CreateHotelPolicyDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelPolicies",
                new { Flag = 2, PolicyId=policyId, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeletePolicyAsync(int policyId)
        {
            return await _connection.ExecuteAsync(
                "sp_HotelPolicies",
                new { Flag = 3, PolicyId=policyId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelPolicy>> GetAllPolicyAsync()
        {
            return await _connection.QueryAsync<HotelPolicy>(
                "sp_HotelPolicies",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelPolicy> GetPolicyByIdAsync(int policyId)
        {
            return await _connection.QueryFirstOrDefaultAsync<HotelPolicy>(
                "sp_HotelPolicies",
                new { Flag = 5, PolicyId = policyId },
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
