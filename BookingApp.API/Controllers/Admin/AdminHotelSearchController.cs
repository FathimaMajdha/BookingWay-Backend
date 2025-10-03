using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminHotelSearchController : ControllerBase
    {
        private readonly IAdminHotelSearchService _adminHotelSearchService;

        public AdminHotelSearchController(IAdminHotelSearchService adminHotelSearchService)
        {
            _adminHotelSearchService = adminHotelSearchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelSearches()
        {
            var result = await _adminHotelSearchService.GetAllHotelSearchesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelSearchById(int id)
        {
            var result = await _adminHotelSearchService.GetHotelSearchByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddHotelSearch([FromBody] AdminHotelSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelSearchService.AddHotelSearchAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelSearchById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelSearch(int id, [FromBody] AdminHotelSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelSearchService.UpdateHotelSearchAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelSearch(int id)
        {
            var result = await _adminHotelSearchService.DeleteHotelSearchAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}