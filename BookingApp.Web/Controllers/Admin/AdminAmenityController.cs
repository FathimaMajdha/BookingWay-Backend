using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Infrastructure.Services.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/admin/hotelamenity")]
    [ApiController]
    public class AdminAmenityController : ControllerBase
    {

       private readonly IAdminAmenityService _service;

            public AdminAmenityController(IAdminAmenityService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> AddAmenity([FromBody] AdminAmenityDto dto)
            {
                var id = await _service.AddAmenityAsync(dto);
                return Ok(id);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAmenity(int id, [FromBody] AdminAmenityDto dto)
            {
                var rows = await _service.UpdateAmenityAsync(id, dto);
                return Ok(rows);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAmenity(int id)
            {
                var rows = await _service.DeleteAmenityAsync(id);
                return Ok(rows);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllAmenities([FromQuery] int? hotelId)
            {
                var list = await _service.GetAllAmenitysAsync(hotelId);
                return Ok(list);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetAmenityById(int id)
            {
                var item = await _service.GetAmenityByIdAsync(id);
                return Ok(item);
            }
       
    }
}

