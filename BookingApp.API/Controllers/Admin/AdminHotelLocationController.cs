using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminHotelLocationController : ControllerBase
    {
        private readonly IAdminHotelLocationService _adminHotelLocationService;

        public AdminHotelLocationController(IAdminHotelLocationService adminHotelLocationService)
        {
            _adminHotelLocationService = adminHotelLocationService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            var result = await _adminHotelLocationService.GetAllLocationsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var result = await _adminHotelLocationService.GetLocationByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddLocation([FromBody] AdminHotelLocationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelLocationService.AddLocationAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetLocationById), new { id = result.Data }, result);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] AdminHotelLocationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelLocationService.UpdateLocationAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var result = await _adminHotelLocationService.DeleteLocationAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}