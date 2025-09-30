using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> AddPaymentAsync(PaymentDto dto);
        Task<int> UpdatePaymentMethodAsync(PaymentDto dto);
        Task<int> DeletePaymentAsync(int paymentId);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int paymentId);
        

    }

}

