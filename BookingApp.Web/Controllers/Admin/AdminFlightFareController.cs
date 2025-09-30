using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFlightFareController : ControllerBase
    {
        private readonly IAdminFlightFareService _flightFareService;

        public AdminFlightFareController(IAdminFlightFareService flightFareService)
        {
            _flightFareService = flightFareService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFlightFare([FromBody] AdminFlightFareDto dto)
        {
            var result = await _flightFareService.AddFlightFareAsync(dto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut("update/{fareId}")]
        public async Task<IActionResult> UpdateFlightFare(int fareId, [FromBody] AdminFlightFareDto dto)
        {
            var result = await _flightFareService.UpdateFlightFareAsync(fareId, dto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("delete/{fareId}")]
        public async Task<IActionResult> DeleteFlightFare(int fareId)
        {
            var result = await _flightFareService.DeleteFlightFareAsync(fareId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllFlightFares([FromQuery] int? flightId = null)
        {
            var result = await _flightFareService.GetAllFlightFaresAsync(flightId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{fareId}")]
        public async Task<IActionResult> GetFlightFareById(int fareId)
        {
            var result = await _flightFareService.GetFlightFareByIdAsync(fareId);
            if (result.Success)
                return Ok(result);
            else
                return NotFound(result);
        }
    }
}