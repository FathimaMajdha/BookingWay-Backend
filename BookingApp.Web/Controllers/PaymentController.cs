using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        private readonly RazorpayConfig _config;

        public PaymentController(IPaymentService service, RazorpayConfig config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDto dto)
        {
            if (dto == null)
                return BadRequest("DTO is null");

            var response = await _service.AddPaymentAsync(dto);

            if (!response.Success || response.Data == 0)
                return BadRequest(response.Message ?? "Payment not added");

            return Ok(new { PaymentId = response.Data, Message = "Payment added successfully" });
        }


        [HttpPut("update-method")]
        public async Task<IActionResult> UpdatePaymentMethod([FromBody] PaymentMethodDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var response = await _service.UpdatePaymentMethodAsync(dto.BookingId, dto.Payment_Method);

            if (!response.Success || response.Data == 0)
                return BadRequest(response.Message ?? "Update Failed");

            return Ok(new { BookingId = dto.BookingId, Message = "Updated Successfully" });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var response = await _service.DeletePaymentAsync(id);

            if (!response.Success || response.Data == 0)
                return BadRequest(response.Message ?? "Delete Failed");

            return Ok(new { PaymentId = id, Message = "Deleted Successfully" });
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _service.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var payment = await _service.GetPaymentByIdAsync(id);
            return payment != null ? Ok(payment) : NotFound();
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var orderId = await _service.CreateRazorpayOrder(dto.Amount, dto.BookingId);

            return Ok(new
            {
                OrderId = orderId,
                Key = _config.Key
            });
        }

        [HttpPost("verify-payment")]
        public IActionResult VerifyPayment([FromBody] VerifyPaymentDto dto)
        {
            var response = _service.VerifyRazorpayPayment(
                dto.RazorpayOrderId,
                dto.RazorpayPaymentId,
                dto.RazorpaySignature
            );

            if (!response.Success || !response.Data)
                return BadRequest(response.Message ?? "Payment Verification Failed");

            return Ok(new { Message = "Payment Verified Successfully" });
        }

    }
}
