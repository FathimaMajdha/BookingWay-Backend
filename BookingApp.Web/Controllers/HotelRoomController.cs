using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoomService _service;

        public HotelRoomController(IHotelRoomService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom([FromBody] HotelRoomDto dto)
        {
            var id = await _service.AddRoomAsync(dto);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] HotelRoomDto dto)
        {
            var updated = await _service.UpdateRoomAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var deleted = await _service.DeleteRoomAsync(id);
            return Ok(deleted);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _service.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _service.GetRoomByIdAsync(id);
            return Ok(room);
        }
    }
}
