using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminHotelController : ControllerBase
    {
        private readonly IAdminHotelService _adminHotelService;

        public AdminHotelController(IAdminHotelService adminHotelService)
        {
            _adminHotelService = adminHotelService;
        }

     
        [HttpGet]
        public async Task<IActionResult> GetAllHotels([FromQuery] int? hotelSearchId = null)
        {
            var result = await _adminHotelService.GetAllHotelsAsync(hotelSearchId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var result = await _adminHotelService.GetHotelByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] AdminHotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelService.AddHotelAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] AdminHotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelService.UpdateHotelAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var result = await _adminHotelService.DeleteHotelAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}