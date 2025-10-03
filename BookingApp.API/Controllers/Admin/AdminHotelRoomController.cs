using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class AdminHotelRoomController : ControllerBase
    {
        private readonly IAdminHotelRoomService _adminHotelRoomService;

        public AdminHotelRoomController(IAdminHotelRoomService adminHotelRoomService)
        {
            _adminHotelRoomService = adminHotelRoomService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllHotelRooms([FromQuery] int? hotelId = null)
        {
            var result = await _adminHotelRoomService.GetAllHotelRoomAsync(hotelId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelRoomById(int id)
        {
            var result = await _adminHotelRoomService.GetHotelRoomByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddHotelRoom([FromBody] AdminHotelRoomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelRoomService.AddHotelRoomAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelRoomById), new { id = result.Data }, result);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelRoom(int id, [FromBody] AdminHotelRoomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _adminHotelRoomService.UpdateHotelRoomAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelRoom(int id)
        {
            var result = await _adminHotelRoomService.DeleteHotelRoomAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}