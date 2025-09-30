using BookingApp.Application.Common;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repo;
        private readonly RazorpayConfig _config;

        public PaymentService(IPaymentRepository repo, RazorpayConfig config)
        {
            _repo = repo;
            _config = config;
        }

        public async Task<ApiResponse<int>> AddPaymentAsync(PaymentDto dto)
        {
            try
            {
                var result = await _repo.AddPaymentAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Payment added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding payment: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdatePaymentMethodAsync(int bookingId, string paymentMethod)
        {
            try
            {
                var dto = new PaymentDto { BookingId = bookingId, Payment_Method = paymentMethod };
                var result = await _repo.UpdatePaymentMethodAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Payment method updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating payment method: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeletePaymentAsync(int paymentId)
        {
            try
            {
                var result = await _repo.DeletePaymentAsync(paymentId);
                return ApiResponse<int>.SuccessResponse(result, "Payment deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting payment: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Domain.Entities.Payment>>> GetAllPaymentsAsync()
        {
            try
            {
                var result = await _repo.GetAllPaymentsAsync();
                return ApiResponse<IEnumerable<Domain.Entities.Payment>>.SuccessResponse(result, "Payments fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Domain.Entities.Payment>>.FailResponse($"Error fetching payments: {ex.Message}");
            }
        }

        public async Task<ApiResponse<Domain.Entities.Payment?>> GetPaymentByIdAsync(int paymentId)
        {
            try
            {
                var result = await _repo.GetPaymentByIdAsync(paymentId);
                if (result == null) return ApiResponse<Domain.Entities.Payment?>.FailResponse("Payment not found.");
                return ApiResponse<Domain.Entities.Payment?>.SuccessResponse(result, "Payment fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<Domain.Entities.Payment?>.FailResponse($"Error fetching payment: {ex.Message}");
            }
        }

        public async Task<ApiResponse<string>> CreateRazorpayOrder(decimal amount, int bookingId)
        {
            try
            {
                RazorpayClient client = new RazorpayClient(_config.Key, _config.Secret);
                var options = new Dictionary<string, object>
                {
                    { "amount", (int)(amount * 100) },
                    { "currency", "INR" },
                    { "receipt", $"receipt_{bookingId}" },
                    { "payment_capture", 1 }
                };

                Order order = client.Order.Create(options);
                return ApiResponse<string>.SuccessResponse(order["id"].ToString(), "Razorpay order created successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.FailResponse($"Error creating Razorpay order: {ex.Message}");
            }
        }

        public ApiResponse<bool> VerifyRazorpayPayment(string razorpayOrderId, string razorpayPaymentId, string razorpaySignature)
        {
            try
            {
                string payload = razorpayOrderId + "|" + razorpayPaymentId;
                using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_config.Secret));
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                string generatedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return ApiResponse<bool>.SuccessResponse(generatedSignature == razorpaySignature, "Payment verification completed.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailResponse($"Error verifying payment: {ex.Message}");
            }
        }
    }
}
