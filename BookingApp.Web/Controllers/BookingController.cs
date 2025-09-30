using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Api.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpGet("mybookings")]
        public async Task<IActionResult> GetMyBookings()
        {
            try
            {
                var userAuthIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAuthId");
                if (userAuthIdClaim == null)
                    return Unauthorized(new { Message = "User authentication claim missing." });

                var userAuthId = int.Parse(userAuthIdClaim.Value);

                var myBookings = await _service.GetMyBookingsAsync(userAuthId);

                if (myBookings == null || myBookings.Data == null || !myBookings.Data.Any())
                    return NotFound(new { Message = "No bookings found." });

                return Ok(myBookings);

            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
