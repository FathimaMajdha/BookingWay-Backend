using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFlightsController : ControllerBase
    {
        private readonly IAdminFlightService _service;

        public AdminFlightsController(IAdminFlightService service)
        {
            _service = service;
        }

        [HttpGet("flight-search")]
        public async Task<IActionResult> GetAllFlightSearch() => Ok(await _service.GetAllFlightSearchAsync());

        [HttpGet("flight-search/{id}")]
        public async Task<IActionResult> GetFlightSearchById(int id)
        {
            var result = await _service.GetFlightSearchByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("flight-search")]
        public async Task<IActionResult> AddFlightSearch([FromBody] SearchDto dto)
        {
            var id = await _service.AddFlightSearchAsync(dto);
            return Ok(new { Id = id });
        }

        [HttpPut("flight-search/{id}")]
        public async Task<IActionResult> UpdateFlightSearch(int id, [FromBody] FlightSearchDto dto)
        {
            var updated = await _service.UpdateFlightSearchAsync(id, dto);
            return Ok(new { UpdatedId = updated });
        }

        [HttpDelete("flight-search/{id}")]
        public async Task<IActionResult> DeleteFlightSearch(int id)
        {
            var deleted = await _service.DeleteFlightSearchAsync(id);
            return Ok(new { DeletedId = deleted });
        }

       
        [HttpGet("flight")]
        public async Task<IActionResult> GetAllFlights([FromQuery] int? flightSearchId = null)
            => Ok(await _service.GetAllFlightsAsync(flightSearchId));

        [HttpGet("flight/{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var result = await _service.GetFlightByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost("flight")]
        public async Task<IActionResult> AddFlight([FromBody] AdminFlightDto dto)
        {
            var id = await _service.AddFlightAsync(dto);
            return Ok(new { Id = id });
        }

        [HttpPut("flight/{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] AdminFlightDto dto)
        {
            var updated = await _service.UpdateFlightAsync(id, dto);
            return Ok(new { UpdatedId = updated });
        }

        [HttpDelete("flight/{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var deleted = await _service.DeleteFlightAsync(id);
            return Ok(new { DeletedId = deleted });
        }
    }
}
