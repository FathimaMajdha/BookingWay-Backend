using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        
        [HttpGet("my-bookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID in token");

            var result = await _bookingService.GetMyBookingsAsync(userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("flight-bookings")]
        public async Task<IActionResult> GetMyFlightBookings()
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID in token");

            var result = await _bookingService.GetMyFlightBookingsAsync(userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("hotel-bookings")]
        public async Task<IActionResult> GetMyHotelBookings()
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID in token");

            var result = await _bookingService.GetMyHotelBookingsAsync(userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{myBookingId}")]
        public async Task<IActionResult> DeleteBooking(int myBookingId)
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID in token");

            var result = await _bookingService.DeleteBookingAsync(myBookingId, userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}