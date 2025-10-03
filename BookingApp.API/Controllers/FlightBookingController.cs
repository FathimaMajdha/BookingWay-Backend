using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class FlightBookingController : ControllerBase
    {
        private readonly IFlightBookingService _flightBookingService;

        public FlightBookingController(IFlightBookingService flightBookingService)
        {
            _flightBookingService = flightBookingService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _flightBookingService.GetAllBookingsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _flightBookingService.GetBookingByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpGet("flight/{flightId}")]
        public async Task<IActionResult> GetBookingsByFlightId(int flightId)
        {
            var result = await _flightBookingService.GetBookingsByFlightIdAsync(flightId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] FlightBookingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightBookingService.CreateBookingAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetBookingById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] Application.DTOs.RazorpayVerificationRequest dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightBookingService.UpdateBookingAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _flightBookingService.DeleteBookingAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}