using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
   
    public class AdminSimilarPropertyController : ControllerBase
    {
        private readonly IAdminSimilarPropertyService _adminSimilarPropertyService;

        public AdminSimilarPropertyController(IAdminSimilarPropertyService adminSimilarPropertyService)
        {
            _adminSimilarPropertyService = adminSimilarPropertyService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllProperties()
        {
            var result = await _adminSimilarPropertyService.GetAllpropsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            var result = await _adminSimilarPropertyService.GetpropByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpGet("similar/{hotelId}")]
        public async Task<IActionResult> GetSimilarProperties(int hotelId)
        {
            var result = await _adminSimilarPropertyService.GetSimilarPropertiesAsync(hotelId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddProperty([FromBody] AdminSimilarPropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminSimilarPropertyService.AddpropAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetPropertyById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromBody] AdminSimilarPropertyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminSimilarPropertyService.UpdatepropAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var result = await _adminSimilarPropertyService.DeletepropAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}