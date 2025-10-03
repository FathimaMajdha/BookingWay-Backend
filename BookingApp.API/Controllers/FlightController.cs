using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs;
using BookingApp.Application.DTOs.FlightDtos;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }


        #region Flight CRUD Operations

        
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            var result = await _flightService.GetAllFlightAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var result = await _flightService.GetFlightByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] FlightCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddFlightAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetFlightById), new { id = result.Data }, result);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.UpdateFlightAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var result = await _flightService.DeleteFlightAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Flight Search Operations

        
        [HttpGet("search")]
        public async Task<IActionResult> GetAllFlightSearches()
        {
            var result = await _flightService.GetAllFlightSearchAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("search/{id}")]
        public async Task<IActionResult> GetFlightSearchById(int id)
        {
            var result = await _flightService.GetFlightSearchByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost("search")]
        public async Task<IActionResult> AddFlightSearch([FromBody] SearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddFlightSearchAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPut("search")]
        public async Task<IActionResult> UpdateFlightSearch([FromBody] FlightSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.UpdateFlightSearchAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("search/{id}")]
        public async Task<IActionResult> DeleteFlightSearch(int id)
        {
            var result = await _flightService.DeleteFlightSearchAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Offers & Popular Routes

        
        [HttpGet("offers")]
        public async Task<IActionResult> GetFlightOffers()
        {
            var result = await _flightService.GetOffersAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("offers")]
        public async Task<IActionResult> AddFlightOffer([FromBody] FlightOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddFlightOfferAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("popular-routes")]
        public async Task<IActionResult> GetPopularRoutes()
        {
            var result = await _flightService.GetPopularRoutesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("popular-routes")]
        public async Task<IActionResult> AddPopularRoute([FromBody] PopularRoutesDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddPopularRouteAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region FAQs

        
        [HttpGet("faqs")]
        public async Task<IActionResult> GetFlightFaqs()
        {
            var result = await _flightService.GetFaqsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("faqs")]
        public async Task<IActionResult> AddFlightFaq([FromBody] FlightFaqDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _flightService.AddFlightFaqAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion



    }
}