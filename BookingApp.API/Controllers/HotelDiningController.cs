using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelPropertyDto;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelDiningController : ControllerBase
    {
        private readonly IHotelDiningService _hotelDiningService;

        public HotelDiningController(IHotelDiningService hotelDiningService)
        {
            _hotelDiningService = hotelDiningService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllHotelDining()
        {
            var result = await _hotelDiningService.GetAllHotelDiningAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiningById(int id)
        {
            var result = await _hotelDiningService.GetDiningByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddHotelDining([FromBody] HotelDiningDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelDiningService.AddHotelDiningAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetDiningById), new { id = result.Data }, result);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotelDining(int id, [FromBody] HotelDiningDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelDiningService.UpdateHotelDiningAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDining(int id)
        {
            var result = await _hotelDiningService.DeleteHotelDiningAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}