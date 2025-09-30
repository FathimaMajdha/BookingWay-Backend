using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Infrastructure.Services.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/admin/hotelroom")]
    [ApiController]
    public class AdminHotelRoomController : ControllerBase
    {

            private readonly IAdminHotelRoomService _service;

            public AdminHotelRoomController(IAdminHotelRoomService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> AddRooms([FromBody] AdminHotelRoomDto dto)
            {
                var id = await _service.AddHotelRoomAsync(dto);
                return Ok(id);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateRooms(int id, [FromBody] AdminHotelRoomDto dto)
            {
                var rows = await _service.UpdateHotelRoomAsync(id, dto);
                return Ok(rows);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteRooms(int id)
            {
                var rows = await _service.DeleteHotelRoomAsync(id);
                return Ok(rows);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllRooms([FromQuery] int? hotelId)
            {
                var list = await _service.GetAllHotelRoomAsync(hotelId);
                return Ok(list);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetHotelRoomById(int id)
            {
                var item = await _service.GetHotelRoomByIdAsync(id);
                return Ok(item);
            }
        
    }
}
