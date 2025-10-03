using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.FlightDtos;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightFareController : ControllerBase
    {
        private readonly IFlightFareService _flightFareService;

        public FlightFareController(IFlightFareService flightFareService)
        {
            _flightFareService = flightFareService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllFares()
        {
            var result = await _flightFareService.GetAllfaresAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFareById(int id)
        {
            var result = await _flightFareService.GetfareByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpGet("flight/{flightId}")]
        public async Task<IActionResult> GetFaresByFlight(int flightId)
        {
            var result = await _flightFareService.GetfaresbyflightAsync(flightId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> AddFare([FromBody] FlightFareDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightFareService.AddfareAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetFareById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFare(int id, [FromBody] FlightFareDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightFareService.UpdatefareAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFare(int id)
        {
            var result = await _flightFareService.DeletefareAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}