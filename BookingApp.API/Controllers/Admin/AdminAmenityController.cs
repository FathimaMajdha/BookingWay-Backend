using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Authorization;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
   
    public class AdminAmenityController : ControllerBase
    {
        private readonly IAdminAmenityService _adminAmenityService;

        public AdminAmenityController(IAdminAmenityService adminAmenityService)
        {
            _adminAmenityService = adminAmenityService;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAllAmenities([FromQuery] int? hotelId = null)
        {
            var result = await _adminAmenityService.GetAllAmenitysAsync(hotelId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmenityById(int id)
        {
            var result = await _adminAmenityService.GetAmenityByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddAmenity([FromBody] AdminAmenityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminAmenityService.AddAmenityAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetAmenityById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmenity(int id, [FromBody] AdminAmenityDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminAmenityService.UpdateAmenityAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            var result = await _adminAmenityService.DeleteAmenityAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}