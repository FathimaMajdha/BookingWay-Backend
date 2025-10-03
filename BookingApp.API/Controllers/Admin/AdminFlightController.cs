using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.FlightDtos;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminFlightController : ControllerBase
    {
        private readonly IAdminFlightService _adminFlightService;

        public AdminFlightController(IAdminFlightService adminFlightService)
        {
            _adminFlightService = adminFlightService;
        }

        #region Flight Search Endpoints

        [HttpGet("search")]
        public async Task<IActionResult> GetAllFlightSearches()
        {
            var result = await _adminFlightService.GetAllFlightSearchAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("search/{id}")]
        public async Task<IActionResult> GetFlightSearchById(int id)
        {
            var result = await _adminFlightService.GetFlightSearchByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost("search")]
        public async Task<IActionResult> AddFlightSearch([FromBody] SearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminFlightService.AddFlightSearchAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetFlightSearchById), new { id = result.Data }, result);
        }

       
        [HttpPut("search/{id}")]
        public async Task<IActionResult> UpdateFlightSearch(int id, [FromBody] FlightSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminFlightService.UpdateFlightSearchAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpDelete("search/{id}")]
        public async Task<IActionResult> DeleteFlightSearch(int id)
        {
            var result = await _adminFlightService.DeleteFlightSearchAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Flight Endpoints

        
        [HttpGet]
        public async Task<IActionResult> GetAllFlights([FromQuery] int? flightSearchId = null)
        {
            var result = await _adminFlightService.GetAllFlightsAsync(flightSearchId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var result = await _adminFlightService.GetFlightByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] AdminFlightDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminFlightService.AddFlightAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetFlightById), new { id = result.Data }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] AdminFlightDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminFlightService.UpdateFlightAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var result = await _adminFlightService.DeleteFlightAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion
    }
}