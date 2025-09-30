using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightFareController : ControllerBase
    {
        private readonly IFlightFareService _service;

        public FlightFareController(IFlightFareService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Addfare([FromBody] FlightFareDto dto)
        {
            var result = await _service.AddfareAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{fareId}")]
        public async Task<IActionResult> Updatefare(int fareId, [FromBody] FlightFareDto dto)
        {

            var updated = await _service.UpdatefareAsync(fareId, dto);
            return Ok(updated);
        }

        [HttpDelete("delete/{fareId}")]
        public async Task<IActionResult> Deletefare(int fareId)
        {
            await _service.DeletefareAsync(fareId);
            return Ok(new { message = "similar property deleted successfully." });
        }



        [HttpGet]
        public async Task<IActionResult> GetAllfares()
        {
            var fare = await _service.GetAllfaresAsync();
            return Ok(fare);
        }

        [HttpGet("{fareId}")]
        public async Task<IActionResult> GetfareById(int fareId)
        {
            var farebyid = await _service.GetfareByIdAsync(fareId);
            return Ok(farebyid);
        }

        [HttpGet("flightFare/{flightId}")]
        public async Task<IActionResult> GetfareFlightById(int flightId)
        {
            var fare = await _service.GetfaresbyflightAsync(flightId);
            return Ok(fare);
        }
    }
}
