using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDiningController : ControllerBase
    {

        private readonly IHotelDiningService _service;

        public HotelDiningController(IHotelDiningService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDining([FromBody] HotelDiningDto dto)
        {
            var result = await _service.AddHotelDiningAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{diningId}")]
        public async Task<IActionResult> UpdateDining(int diningId, [FromBody] HotelDiningDto dto)
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
