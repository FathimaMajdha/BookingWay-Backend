using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTO;
using BookingApp.Application.DTOs;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  
    public class HotelBookingController : ControllerBase
    {
        private readonly IHotelBookingService _hotelBookingService;

        public HotelBookingController(IHotelBookingService hotelBookingService)
        {
            _hotelBookingService = hotelBookingService;
        }

        [HttpGet("my-bookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized(new { Success = false, Message = "Invalid user ID in token." });
            }

            var result = await _hotelBookingService.GetBookingsByUserAsync(userId);
            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] HotelBookingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized(new { Success = false, Message = "Invalid user ID in token." });
            }

            var result = await _hotelBookingService.CreateBookingAsync(dto, userId);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetBookingById), new { id = result.Data }, result);
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _hotelBookingService.GetAllBookingsAsync();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _hotelBookingService.GetBookingByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Application.DTOs.RazorpayVerificationRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelBookingService.UpdateBookingAsync(id, dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _hotelBookingService.DeleteBookingAsync(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}