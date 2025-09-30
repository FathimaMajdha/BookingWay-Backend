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
       public class AdminSimilarPropertyController : ControllerBase
        {
            private readonly IAdminSimilarPropertyService _service;

            public AdminSimilarPropertyController(IAdminSimilarPropertyService service)
            {
                _service = service;
            }

            [HttpPost("add")]
            public async Task<IActionResult> Addprop([FromBody] AdminSimilarPropertyDto dto)
            {
                var result = await _service.AddpropAsync(dto);
                return Ok(result);
            }

            [HttpPut("update/{propId}")]
            public async Task<IActionResult> Updateprop(int propId, [FromBody] AdminSimilarPropertyDto dto)
            {

                var updated = await _service.UpdatepropAsync(propId, dto);
                return Ok(updated);
            }

            [HttpDelete("delete/{propId}")]
            public async Task<IActionResult> Deleteprop(int propId)
            {
                await _service.DeletepropAsync(propId);
                return Ok(new { message = "similar property deleted successfully." });
            }



            [HttpGet]
            public async Task<IActionResult> GetAllprops()
            {
                var similar = await _service.GetAllpropsAsync();
                return Ok(similar);
            }

            [HttpGet("{propId}")]
            public async Task<IActionResult> GetpropById(int propId)
            {
                var similar = await _service.GetpropByIdAsync(propId);
                return Ok(similar);
            }

            [HttpGet("hotel/{hotelId}")]
            public async Task<IActionResult> GetsimilarById(int hotelId)
            {
                var similar = await _service.GetSimilarPropertiesAsync(hotelId);
                return Ok(similar);
            }
        }
    
}
