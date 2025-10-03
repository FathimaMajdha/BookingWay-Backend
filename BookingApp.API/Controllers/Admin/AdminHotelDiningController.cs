using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminHotelDiningController : ControllerBase
    {
        private readonly IAdminHotelDiningService _adminHotelDiningService;

        public AdminHotelDiningController(IAdminHotelDiningService adminHotelDiningService)
        {
            _adminHotelDiningService = adminHotelDiningService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllHotelDining()
        {
            var result = await _adminHotelDiningService.GetAllHotelDiningAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelDiningById(int id)
        {
            var result = await _adminHotelDiningService.GetDiningByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddHotelDining([FromBody] AdminHotelDiningDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelDiningService.AddHotelDiningAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelDiningById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelDining(int id, [FromBody] AdminHotelDiningDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelDiningService.UpdateHotelDiningAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDining(int id)
        {
            var result = await _adminHotelDiningService.DeleteHotelDiningAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}