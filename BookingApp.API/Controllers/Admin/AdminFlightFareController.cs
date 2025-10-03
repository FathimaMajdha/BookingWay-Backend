using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class AdminFlightFareController : ControllerBase
    {
        private readonly IAdminFlightFareService _adminFlightFareService;

        public AdminFlightFareController(IAdminFlightFareService adminFlightFareService)
        {
            _adminFlightFareService = adminFlightFareService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllFlightFares([FromQuery] int? flightId = null)
        {
            var result = await _adminFlightFareService.GetAllFlightFaresAsync(flightId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightFareById(int id)
        {
            var result = await _adminFlightFareService.GetFlightFareByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddFlightFare([FromBody] AdminFlightFareDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminFlightFareService.AddFlightFareAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetFlightFareById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlightFare(int id, [FromBody] AdminFlightFareDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminFlightFareService.UpdateFlightFareAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightFare(int id)
        {
            var result = await _adminFlightFareService.DeleteFlightFareAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}