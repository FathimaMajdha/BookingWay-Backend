using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelPropertyDto;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimilarPropertyController : ControllerBase
    {
        private readonly ISimilarPropertyService _similarPropertyService;

        public SimilarPropertyController(ISimilarPropertyService similarPropertyService)
        {
            _similarPropertyService = similarPropertyService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            var result = await _similarPropertyService.GetAllpropsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/similarproperty/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            var result = await _similarPropertyService.GetpropByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/similarproperty/similar/5
        [HttpGet("similar/{hotelId}")]
        public async Task<IActionResult> GetSimilarProperties(int hotelId)
        {
            var result = await _similarPropertyService.GetSimilarPropertiesAsync(hotelId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // POST: api/similarproperty
        [HttpPost]
        public async Task<IActionResult> AddProperty([FromBody] SimilarPropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _similarPropertyService.AddpropAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetPropertyById), new { id = result.Data }, result);
        }

        // PUT: api/similarproperty/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] SimilarPropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _similarPropertyService.UpdatepropAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/similarproperty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await _similarPropertyService.DeletepropAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}