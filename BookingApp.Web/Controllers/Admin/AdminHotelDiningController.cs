using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Infrastructure.Services.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
  
        public class AdminHotelDiningController : ControllerBase
        {

            private readonly IAdminHotelDiningService _service;

            public AdminHotelDiningController(IAdminHotelDiningService service)
            {
                _service = service;
            }

            [HttpPost("add")]
            public async Task<IActionResult> AddDining([FromBody] AdminHotelDiningDto dto)
            {
                var result = await _service.AddHotelDiningAsync(dto);
                return Ok(result);
            }

            [HttpPut("update/{diningId}")]
            public async Task<IActionResult> UpdateDining(int diningId, [FromBody] AdminHotelDiningDto dto)
            {

                var updated = await _service.UpdateHotelDiningAsync(diningId, dto);
                return Ok(updated);
            }

            [HttpDelete("delete/{diningId}")]
            public async Task<IActionResult> DeleteDining(int diningId)
            {
                await _service.DeleteHotelDiningAsync(diningId);
                return Ok(new { message = "Dining deleted successfully." });
            }



            [HttpGet]
            public async Task<IActionResult> GetAllDining()
            {
                var diningall = await _service.GetAllHotelDiningAsync();
                return Ok(diningall);
            }

            [HttpGet("{diningId}")]
            public async Task<IActionResult> GetDiningById(int diningId)
            {
                var diningById = await _service.GetDiningByIdAsync(diningId);
                return Ok(diningById);
            }
        }
    
}
