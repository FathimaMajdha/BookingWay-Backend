using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminBookingController : ControllerBase
    {
        private readonly IAdminBookingService _service;

        public AdminBookingController(IAdminBookingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdminBookings()
        {
            var response = await _service.GetAllAdminBookingsAsync();

            if (response == null || response.Data == null || !response.Data.Any())
                return NotFound("No successful bookings found.");

            return Ok(response);
        }

    }
}
