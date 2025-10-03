using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminOverviewController : ControllerBase
    {
        private readonly IAdminOverviewService _adminOverviewService;

        public AdminOverviewController(IAdminOverviewService adminOverviewService)
        {
            _adminOverviewService = adminOverviewService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetOverview()
        {
            var result = await _adminOverviewService.GetOverviewAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("revenue-by-user")]
        public async Task<IActionResult> GetRevenueByUser()
        {
            var result = await _adminOverviewService.GetRevenueByUserAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("bookings-per-user")]
        public async Task<IActionResult> GetBookingsPerUser()
        {
            var result = await _adminOverviewService.GetBookingsPerUserAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("daily-revenue")]
        public async Task<IActionResult> GetDailyRevenueTrend()
        {
            var result = await _adminOverviewService.GetDailyRevenueTrendAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("recent-activities")]
        public async Task<IActionResult> GetRecentActivities()
        {
            var result = await _adminOverviewService.GetRecentActivitiesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("top-hotels")]
        public async Task<IActionResult> GetTopHotels()
        {
            var result = await _adminOverviewService.GetTopHotelsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("top-flights")]
        public async Task<IActionResult> GetTopFlights()
        {
            var result = await _adminOverviewService.GetTopFlightsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("hotel-offers")]
        public async Task<IActionResult> GetHotelOffers()
        {
            var result = await _adminOverviewService.GetHotelOffersAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("flight-offers")]
        public async Task<IActionResult> GetFlightOffers()
        {
            var result = await _adminOverviewService.GetFlightOffersAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}