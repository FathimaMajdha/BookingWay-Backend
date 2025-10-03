using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelPropertyDto;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelLocationController : ControllerBase
    {
        private readonly IHotelLocationService _hotelLocationService;

        public HotelLocationController(IHotelLocationService hotelLocationService)
        {
            _hotelLocationService = hotelLocationService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _hotelLocationService.GetAllLocationsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var result = await _hotelLocationService.GetLocationByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] CreateHotelLocationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelLocationService.AddLocationAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetLocationById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] CreateHotelLocationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelLocationService.UpdateLocationAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var result = await _hotelLocationService.DeleteLocationAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}