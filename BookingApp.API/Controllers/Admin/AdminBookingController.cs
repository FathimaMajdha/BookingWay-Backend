using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminBookingController : ControllerBase
    {
        private readonly IAdminBookingService _adminBookingService;

        public AdminBookingController(IAdminBookingService adminBookingService)
        {
            _adminBookingService = adminBookingService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _adminBookingService.GetAllAdminBookingsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}