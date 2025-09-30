using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminHotelLocationController : ControllerBase
    {
        private readonly IAdminHotelLocationService _service;

        public AdminHotelLocationController(IAdminHotelLocationService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLocation([FromBody] AdminHotelLocationDto dto)
        {
            var result = await _service.AddLocationAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{locationId}")]
        public async Task<IActionResult> UpdateLocation(int locationId, [FromBody] AdminHotelLocationDto dto)
        {

            var updated = await _service.UpdateLocationAsync(locationId, dto);
            return Ok(updated);
        }

        [HttpDelete("delete/{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            await _service.DeleteLocationAsync(locationId);
            return Ok(new { message = "Location deleted successfully." });
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
