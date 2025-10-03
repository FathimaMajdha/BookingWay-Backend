using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
   
    public class AdminHotelPolicyController : ControllerBase
    {
        private readonly IAdminHotelPolicyService _adminHotelPolicyService;

        public AdminHotelPolicyController(IAdminHotelPolicyService adminHotelPolicyService)
        {
            _adminHotelPolicyService = adminHotelPolicyService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllHotelPolicies([FromQuery] int? hotelId = null)
        {
            var result = await _adminHotelPolicyService.GetAllHotelPolicyAsync(hotelId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelPolicyById(int id)
        {
            var result = await _adminHotelPolicyService.GetHotelPolicyByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddHotelPolicy([FromBody] AdminHotelPolicyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelPolicyService.AddHotelpolicyAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelPolicyById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelPolicy(int id, [FromBody] AdminHotelPolicyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelPolicyService.UpdateHotelpolicyAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/admin/adminhotelpolicy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelPolicy(int id)
        {
            var result = await _adminHotelPolicyService.DeleteHotelpolicyAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}