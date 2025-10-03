using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelDetailController : ControllerBase
    {
        private readonly IHotelDetailService _hotelDetailService;

        public HotelDetailController(IHotelDetailService hotelDetailService)
        {
            _hotelDetailService = hotelDetailService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllHotelDetails()
        {
            var result = await _hotelDetailService.GetHotelDetailsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelDetailById(int id)
        {
            var result = await _hotelDetailService.GetHotelDetailByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDetail(int id)
        {
            var result = await _hotelDetailService.DeleteHotelDetailAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}