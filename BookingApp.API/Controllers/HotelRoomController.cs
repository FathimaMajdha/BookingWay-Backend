using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelPropertyDto;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoomService _hotelRoomService;

        public HotelRoomController(IHotelRoomService hotelRoomService)
        {
            _hotelRoomService = hotelRoomService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var result = await _hotelRoomService.GetAllRoomsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var result = await _hotelRoomService.GetRoomByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] HotelRoomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelRoomService.AddRoomAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetRoomById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] HotelRoomDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelRoomService.UpdateRoomAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _hotelRoomService.DeleteRoomAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}