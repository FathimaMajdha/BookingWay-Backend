using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelPropertyDto;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelPolicyController : ControllerBase
    {
        private readonly IHotelPolicyService _hotelPolicyService;

        public HotelPolicyController(IHotelPolicyService hotelPolicyService)
        {
            _hotelPolicyService = hotelPolicyService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllPolicies()
        {
            var result = await _hotelPolicyService.GetAllPolicyAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicyById(int id)
        {
            var result = await _hotelPolicyService.GetPolicyByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddPolicy([FromBody] CreateHotelPolicyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelPolicyService.AddpolicyAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetPolicyById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePolicy(int id, [FromBody] CreateHotelPolicyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelPolicyService.UpdatePolicyAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            var result = await _hotelPolicyService.DeletePolicyAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}