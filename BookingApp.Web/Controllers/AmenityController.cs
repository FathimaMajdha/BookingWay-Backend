using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityService _service;

        public AmenityController(IAmenityService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAmenity([FromBody] AmenityDto dto)
        {
            var result = await _service.AddAmenityAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{amenityId}")]
        public async Task<IActionResult> UpdateAmenity(int amenityId, [FromBody] AmenityDto dto)
        {

            var updated = await _service.UpdateAmenityAsync(amenityId, dto);
            return Ok(updated);
        }

        [HttpDelete("delete/{amenityId}")]
        public async Task<IActionResult> DeleteAmenity(int amenityId)
        {
            await _service.DeleteAmenityAsync(amenityId);
            return Ok(new { message = "Amenity deleted successfully." });
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAmenities()
        {
            var amenities = await _service.GetAllAmenitiesAsync();
            return Ok(amenities);
        }

        [HttpGet("{amenityId}")]
        public async Task<IActionResult> GetAmenityById(int amenityId)
        {
            var amenity = await _service.GetAmenityByIdAsync(amenityId);
            return Ok(amenity);
        }
    }
}
