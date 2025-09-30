using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightBookingController : ControllerBase
    {
        private readonly IFlightBookingService _service;

        public FlightBookingController(IFlightBookingService service)
        {
            _service = service;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] FlightBookingDto dto)
        {
            var userAuthIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAuthId");
            if (userAuthIdClaim != null)
                dto.UserAuthId = int.Parse(userAuthIdClaim.Value);

            var id = await _service.CreateBookingAsync(dto);
            return Ok(new { InsertedId = id });
        }


        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] VerifyPaymentDto dto)
        {
            var id = await _service.UpdateBookingAsync(bookingId, dto);
            return Ok(new { UpdatedId = id });
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            await _service.DeleteBookingAsync(bookingId);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _service.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetBookingById(int bookingId)
        {
            var booking = await _service.GetBookingByIdAsync(bookingId);
            return Ok(booking);
        }

        [HttpGet("by-flight/{flightId}")]
        public async Task<IActionResult> GetBookingsByFlight(int flightId)
        {
            var bookings = await _service.GetBookingsByFlightIdAsync(flightId);
            return Ok(bookings);
        }
    }
}
