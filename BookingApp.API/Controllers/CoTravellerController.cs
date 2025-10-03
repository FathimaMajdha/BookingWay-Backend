using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CoTravellerController : ControllerBase
    {
        private readonly ICoTravellerService _coTravellerService;

        public CoTravellerController(ICoTravellerService coTravellerService)
        {
            _coTravellerService = coTravellerService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllCoTravellers()
        {
            var result = await _coTravellerService.GetAllCoTravellersAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoTravellerById(int id)
        {
            var result = await _coTravellerService.GetCoTravellersByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddCoTraveller([FromBody] CoTravellerDto traveller)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
                return Unauthorized("Invalid user ID in token");

            var result = await _coTravellerService.AddCoTravellerAsync(userId, traveller);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetCoTravellerById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoTraveller(int id, [FromBody] CoTravellerDto traveller)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _coTravellerService.UpdateCoTravellerAsync(id, traveller);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoTraveller(int id)
        {
            var result = await _coTravellerService.DeleteCoTravellerAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}