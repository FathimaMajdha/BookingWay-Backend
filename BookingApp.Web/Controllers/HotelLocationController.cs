using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelLocationController : ControllerBase
    {
        private readonly IHotelLocationService _service;

        public HotelLocationController(IHotelLocationService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLocation([FromBody] CreateHotelLocationDto dto)
        {
            var result = await _service.AddLocationAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{locationId}")]
        public async Task<IActionResult> UpdateLocation(int locationId, [FromBody] CreateHotelLocationDto dto)
        {

            var updated = await _service.UpdateLocationAsync(locationId, dto);
            return Ok(updated);
        }

        [HttpDelete("delete/{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            await _service.DeleteLocationAsync(locationId);
            return Ok(new { message = "Amenity deleted successfully." });
        }



        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _service.GetAllLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("{locationId}")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            var location = await _service.GetLocationByIdAsync(locationId);
            return Ok(location);
        }
    }
}
