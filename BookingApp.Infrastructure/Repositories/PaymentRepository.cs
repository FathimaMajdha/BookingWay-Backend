using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _connection;

        public PaymentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddPaymentAsync(PaymentDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteScalarAsync<int>(
                "sp_Payment",
                new { Flag = 1, Json = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdatePaymentMethodAsync(PaymentDto dto)
        {
            var json = JsonSerializer.Serialize(dto, new JsonSerializerOptions { PropertyNamingPolicy = null });
            return await _connection.ExecuteAsync(
                "sp_Payment",
                new { Flag = 2, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }


        public async Task<int> DeletePaymentAsync(int paymentId)
        {
            return await _connection.ExecuteAsync(
                "sp_Payment",
                new { Flag = 3, PaymentId = paymentId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _connection.QueryAsync<Payment>(
                "sp_Payment",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            var payments = await _connection.QueryAsync<Payment>(
                "sp_Payment",
                new { Flag = 5 },
                commandType: CommandType.StoredProcedure
            );
            return payments.FirstOrDefault(p => p.PaymentId == paymentId);
        }
    }
}
