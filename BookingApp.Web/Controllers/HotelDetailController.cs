using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDetailController : ControllerBase
    {
        private readonly IHotelDetailService _service;

        public HotelDetailController(IHotelDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotelDetails()
        {
            var details = await _service.GetHotelDetailsAsync();
            return Ok(details);
        }

        [HttpGet("{hotelDetailId}")]
        public async Task<IActionResult> GetHotelDetailById(int hotelDetailId)
        {
            var detail = await _service.GetHotelDetailByIdAsync(hotelDetailId);
            return Ok(detail);
        }

        [HttpDelete("{hotelDetailId}")]
        public async Task<IActionResult> DeleteHotelDetail(int hotelDetailId)
        {
            var deleted = await _service.DeleteHotelDetailAsync(hotelDetailId);
            return Ok(deleted);
        }
    }
}
