using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _service;

        public FlightsController(IFlightService service)
        {
            _service = service;
        }



        [HttpPost("search-add")]
        public async Task<IActionResult> AddSearch([FromBody] SearchDto dto)
        {
            var flightSearchId = await _service.AddFlightSearchAsync(dto);
            return Ok(new { FlightSearchId = flightSearchId, Message = "Search saved successfully." });
        }

        [HttpPut("search-update")]
        public async Task<IActionResult> UpdateSearch([FromBody] FlightSearchDto dto)
        {
            var updatedRows = await _service.UpdateFlightSearchAsync(dto);
            return Ok(new { UpdatedRows = updatedRows, Message = "Search updated successfully." });
        }

        [HttpDelete("search-delete/{id}")]
        public async Task<IActionResult> DeleteSearch(int id)
        {
            var response = await _service.DeleteFlightSearchAsync(id);

            if (!response.Success || response.Data == 0)
                return NotFound(new { FlightSearchId = id, Message = response.Message ?? "Search not found or already deleted." });

            return Ok(new { FlightSearchId = id, Message = "Search deleted successfully." });
        }


        [HttpGet("search-all")]
        public async Task<IActionResult> GetAllSearches()
        {
            var results = await _service.GetAllFlightSearchAsync();
            return Ok(results);
        }

        [HttpGet("search/{id}")]
        public async Task<IActionResult> GetSearchById(int id)
        {
            var result = await _service.GetFlightSearchByIdAsync(id);
            if (result == null)
                return NotFound(new { Message = "Search not found." });

            return Ok(result);
        }




        [HttpPost("Offers-add")]
        public async Task<IActionResult> AddOffers([FromBody] FlightOfferDto dto)
        {
            var results = await _service.AddFlightOfferAsync(dto);
            return Ok(results);
        }

        [HttpGet("offers")]
        public async Task<IActionResult> GetOffers()
        {
            return Ok(await _service.GetOffersAsync());
        }



        [HttpPost("PopularRoutes-add")]
        public async Task<IActionResult> AddPopularRoutes([FromBody] PopularRoutesDto dto)
        {
            var results = await _service.AddPopularRouteAsync(dto);
            return Ok(results);
        }

        [HttpGet("popular-routes")]
        public async Task<IActionResult> GetPopularRoutes()
        {
            return Ok(await _service.GetPopularRoutesAsync());
        }


        [HttpPost("faq-add")]
        public async Task<IActionResult> AddFaq([FromBody] FlightFaqDto dto)
        {
            var results = await _service.AddFlightFaqAsync(dto);
            return Ok(results);
        }

        [HttpGet("faqs")]
        public async Task<IActionResult> GetFaqs()
        {
            return Ok(await _service.GetFaqsAsync());
        }




        [HttpPost("flight-add")]
        public async Task<IActionResult> AddFlight([FromBody] FlightCreateDto dto)
        {
            var results = await _service.AddFlightAsync(dto);
            return Ok(results);
        }



        [HttpPut("update/{flightId}")]
        public async Task<IActionResult> UpdateFlight(int flightId, [FromBody] FlightCreateDto flight)
        {
           
                var updatedFlightId = await _service.UpdateFlightAsync(flightId, flight);
                return Ok(new { FlightId = updatedFlightId, Message = "Flight updated successfully." });
            
        }


        [HttpDelete("delete/{flightId}")]
        public async Task<IActionResult> DeleteFlight(int flightId)
        {
            var response = await _service.DeleteFlightAsync(flightId);

            if (!response.Success || response.Data == 0)
                return NotFound(new { FlightId = flightId, Message = response.Message ?? "Flight not found or already deleted." });

            return Ok(new { FlightId = flightId, Message = "Flight deleted successfully." });
        }


        [HttpGet("all-flights")]
        public async Task<IActionResult> GetAllFlight()
        {
           
                var users = await _service.GetAllFlightAsync();
                return Ok(users);
            
        }

        [HttpGet("get/{flightId}")]
        public async Task<IActionResult> GetFlightById(int flightId)
        {

            var result = await _service.GetFlightByIdAsync(flightId);

            if (result == null)
                return NotFound(new { Message = "Flight not found." });
            return Ok(result);
        }

    }
}
