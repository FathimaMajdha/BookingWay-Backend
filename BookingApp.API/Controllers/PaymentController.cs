using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.DTOs;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var result = await _paymentService.GetAllPaymentsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentById(int id)
        {
            var result = await _paymentService.GetPaymentByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddPayment([FromBody] PaymentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _paymentService.AddPaymentAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetPaymentById), new { id = result.Data }, result);
        }

       
        [HttpPut("method/{bookingId}")]
        public async Task<IActionResult> UpdatePaymentMethod(int bookingId, [FromBody] string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod))
                return BadRequest("Payment method is required");

            var result = await _paymentService.UpdatePaymentMethodAsync(bookingId, paymentMethod);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _paymentService.DeletePaymentAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #region Razorpay Integration

        
        [HttpPost("razorpay/create-order")]
        public async Task<IActionResult> CreateRazorpayOrder([FromBody] RazorpayOrderRequest request)
        {
            if (request.Amount <= 0)
                return BadRequest("Invalid amount");

            if (request.BookingId <= 0)
                return BadRequest("Invalid booking ID");

            var result = await _paymentService.CreateRazorpayOrder(request.Amount, request.BookingId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("razorpay/verify")]
        public IActionResult VerifyRazorpayPayment([FromBody] RazorpayVerificationRequest request)
        {
            if (string.IsNullOrEmpty(request.RazorpayOrderId) ||
                string.IsNullOrEmpty(request.RazorpayPaymentId) ||
                string.IsNullOrEmpty(request.RazorpaySignature))
                return BadRequest("Missing verification parameters");

            var result = _paymentService.VerifyRazorpayPayment(
                request.RazorpayOrderId,
                request.RazorpayPaymentId,
                request.RazorpaySignature
            );

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion
    }


   
}