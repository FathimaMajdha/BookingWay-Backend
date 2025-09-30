using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOverviewController : ControllerBase
    {
        private readonly IAdminOverviewService _service;

        public AdminOverviewController(IAdminOverviewService service)
        {
            _service = service;
        }

        [HttpGet("overview")]
        public async Task<IActionResult> GetOverview() => Ok(await _service.GetOverviewAsync());

        [HttpGet("revenue-by-user")]
        public async Task<IActionResult> GetRevenueByUser() => Ok(await _service.GetRevenueByUserAsync());

        [HttpGet("bookings-per-user")]
        public async Task<IActionResult> GetBookingsPerUser() => Ok(await _service.GetBookingsPerUserAsync());

        [HttpGet("daily-revenue-trend")]
        public async Task<IActionResult> GetDailyRevenueTrend() => Ok(await _service.GetDailyRevenueTrendAsync());

        [HttpGet("recent-activities")]
        public async Task<IActionResult> GetRecentActivities() => Ok(await _service.GetRecentActivitiesAsync());

        [HttpGet("top-hotels")]
        public async Task<IActionResult> GetTopHotels() => Ok(await _service.GetTopHotelsAsync());

        [HttpGet("top-flights")]
        public async Task<IActionResult> GetTopFlights() => Ok(await _service.GetTopFlightsAsync());

        [HttpGet("hotel-offers")]
        public async Task<IActionResult> GetHotelOffers() => Ok(await _service.GetHotelOffersAsync());

        [HttpGet("flight-offers")]
        public async Task<IActionResult> GetFlightOffers() => Ok(await _service.GetFlightOffersAsync());
    }
}
