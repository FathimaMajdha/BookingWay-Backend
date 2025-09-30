using BookingApp.Application.Common;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Domain.Entities;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IPaymentService
    {

        Task<ApiResponse<int>> AddPaymentAsync(PaymentDto dto);
        Task<ApiResponse<int>> UpdatePaymentMethodAsync(int bookingId, string paymentMethod);
        Task<ApiResponse<int>> DeletePaymentAsync(int paymentId);
        Task<ApiResponse<IEnumerable<Domain.Entities.Payment>>> GetAllPaymentsAsync();
        Task<ApiResponse<Domain.Entities.Payment?>> GetPaymentByIdAsync(int paymentId);
        Task<ApiResponse<string>> CreateRazorpayOrder(decimal amount, int bookingId);
        ApiResponse<bool> VerifyRazorpayPayment(string razorpayOrderId, string razorpayPaymentId, string razorpaySignature);

    }

}