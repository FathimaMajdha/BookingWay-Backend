using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Infrastructure.Services.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.API.Controllers.Admin
{
    [Route("api/admin/hotel")]
    [ApiController]
    public class AdminHotelController : ControllerBase
    {
        private readonly IAdminHotelService _service;

        public AdminHotelController(IAdminHotelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AdminHotelDto dto)
        {
            if (dto == null)
                return BadRequest("Hotel data is required");

            var response = await _service.AddHotelAsync(dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AdminHotelDto dto)
        {
            if (dto == null)
                return BadRequest("Hotel data is required");

           
            var existingHotel = await _service.GetHotelByIdAsync(id);
            if (existingHotel == null || existingHotel.Data == null)
            {
                return NotFound($"Hotel with ID {id} not found");
            }

            var response = await _service.UpdateHotelAsync(id, dto);

            if (!response.Success)
            {
                return BadRequest(response.Message ?? "Failed to update hotel.");
            }

           
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteHotelAsync(id);
            if (!response.Success || response.Data == 0)
                return BadRequest(response.Message ?? "No rows deleted. Hotel may not exist.");

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int? hotelSearchId)
        {
            var list = await _service.GetAllHotelsAsync(hotelSearchId);
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetHotelByIdAsync(id);
            return Ok(item);
        }
    }
}
