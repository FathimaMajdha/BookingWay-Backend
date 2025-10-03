using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelPropertyDto;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityService _amenityService;

        public AmenityController(IAmenityService amenityService)
        {
            _amenityService = amenityService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllAmenities()
        {
            var result = await _amenityService.GetAllAmenitiesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmenityById(int id)
        {
            var result = await _amenityService.GetAmenityByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddAmenity([FromBody] AmenityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _amenityService.AddAmenityAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetAmenityById), new { id = result.Data }, result);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmenity(int id, [FromBody] AmenityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _amenityService.UpdateAmenityAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            var result = await _amenityService.DeleteAmenityAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}