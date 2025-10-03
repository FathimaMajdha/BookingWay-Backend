using Microsoft.AspNetCore.Mvc;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs.HotelDtos;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        #region Hotel Search Endpoints

        
        [HttpGet("search")]
        public async Task<IActionResult> GetAllHotelSearches()
        {
            var result = await _hotelService.GetAllHotelSearchesAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("search/{id}")]
        public async Task<IActionResult> GetHotelSearchById(int id)
        {
            var result = await _hotelService.GetHotelSearchByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost("search")]
        public async Task<IActionResult> AddHotelSearch([FromBody] HotelSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddHotelSearchAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelSearchById), new { id = result.Data }, result);
        }

        
        [HttpPut("search")]
        public async Task<IActionResult> UpdateHotelSearch([FromBody] HotelSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.UpdateHotelSearchAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("search/{id}")]
        public async Task<IActionResult> DeleteHotelSearch(int id)
        {
            var result = await _hotelService.DeleteHotelSearchAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("search/query")]
        public async Task<IActionResult> SearchHotels([FromBody] HotelSearchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.SearchHotelsAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Hotel CRUD Endpoints

        [HttpGet]
        public async Task<IActionResult> GetAllHotels([FromQuery] int? hotelSearchId = null)
        {
            var result = await _hotelService.GetAllHotelsAsync(hotelSearchId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var result = await _hotelService.GetHotelByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] HotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddHotelAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetHotelById), new { id = result.Data }, result);
        }

       
        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] HotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.UpdateHotelAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var result = await _hotelService.DeleteHotelAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Hotel Offers Endpoints

        
        [HttpGet("offers")]
        public async Task<IActionResult> GetHotelOffers()
        {
            var result = await _hotelService.GetHotelOffersAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("offers")]
        public async Task<IActionResult> AddHotelOffer([FromBody] HotelOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddHotelOfferAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPut("offers/{id}")]
        public async Task<IActionResult> UpdateHotelOffer(int id, [FromBody] HotelOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.UpdateHotelOfferAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpDelete("offers/{id}")]
        public async Task<IActionResult> DeleteHotelOffer(int id)
        {
            var result = await _hotelService.DeleteHotelOfferAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Daily Deals Endpoints

        
        [HttpGet("daily-deals")]
        public async Task<IActionResult> GetDailyDeals()
        {
            var result = await _hotelService.GetDailyDealsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpGet("daily-deals/{id}")]
        public async Task<IActionResult> GetDailyDealById(int id)
        {
            var result = await _hotelService.GetDailyDealByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        
        [HttpPost("daily-deals")]
        public async Task<IActionResult> AddDailyDeal([FromBody] DailyStealDealDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddDailyDealAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Seasons Endpoints

        
        [HttpGet("seasons")]
        public async Task<IActionResult> GetSeasons()
        {
            var result = await _hotelService.GetSeasonsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpPost("seasons")]
        public async Task<IActionResult> AddSeason([FromBody] DifferentSeasonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddSeasonAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPut("seasons/{id}")]
        public async Task<IActionResult> UpdateSeason(int id, [FromBody] DifferentSeasonDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.UpdateSeasonAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("seasons/{id}")]
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var result = await _hotelService.DeleteSeasonAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region Popular Destinations Endpoints

        [HttpGet("popular-destinations")]
        public async Task<IActionResult> GetPopularDestinations()
        {
            var result = await _hotelService.GetPopularDestinationsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("popular-destinations")]
        public async Task<IActionResult> AddPopularDestination([FromBody] PopularDestinationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddPopularDestinationAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpDelete("popular-destinations/{id}")]
        public async Task<IActionResult> DeletePopularDestination(int id)
        {
            var result = await _hotelService.DeletePopularDestinationAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion

        #region FAQ Endpoints
       
        [HttpGet("faqs")]
        public async Task<IActionResult> GetHotelFaqs()
        {
            var result = await _hotelService.GetHotelFaqsAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

       
        [HttpPost("faqs")]
        public async Task<IActionResult> AddHotelFaq([FromBody] HotelFaqDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _hotelService.AddHotelFaqAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        #endregion
    }
}