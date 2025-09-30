using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelsController(IHotelService service)
        {
            _service = service;
        }

        #region Hotel Search CRUD

        [HttpPost("search")]
        public async Task<IActionResult> SearchHotels([FromBody] HotelSearchDto dto)
        {
            var result = await _service.SearchHotelsAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("search/add")]
        public async Task<IActionResult> AddHotelSearch([FromBody] HotelSearchDto dto)
        {
            var result = await _service.AddHotelSearchAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetHotelSearchById), new { hotelSearchId = result.Data }, result);
        }

        [HttpPut("search/{hotelSearchId}")]
        public async Task<IActionResult> UpdateHotelSearch(int hotelSearchId, [FromBody] HotelSearchDto dto)
        {
            if (dto.HotelSearchId == null)
                dto.HotelSearchId = hotelSearchId;

            var result = await _service.UpdateHotelSearchAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("search/{hotelSearchId}")]
        public async Task<IActionResult> DeleteHotelSearch(int hotelSearchId)
        {
            var result = await _service.DeleteHotelSearchAsync(hotelSearchId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("searches")]
        public async Task<IActionResult> GetAllHotelSearches()
        {
            var result = await _service.GetAllHotelSearchesAsync();
            return Ok(result);
        }

        [HttpGet("search/{hotelSearchId}")]
        public async Task<IActionResult> GetHotelSearchById(int hotelSearchId)
        {
            var result = await _service.GetHotelSearchByIdAsync(hotelSearchId);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
        #endregion

        #region Hotel CRUD

        [HttpPost]
        public async Task<IActionResult> AddHotel([FromBody] HotelDto dto)
        {
            var result = await _service.AddHotelAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetHotelById), new { hotelId = result.Data }, result);
        }

        [HttpPut("{hotelId}")]
        public async Task<IActionResult> UpdateHotel(int hotelId, [FromBody] HotelDto dto)
        {
            if (dto.HotelId == null)
                dto.HotelId = hotelId;

            var result = await _service.UpdateHotelAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("{hotelId}")]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            var result = await _service.DeleteHotelAsync(hotelId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels([FromQuery] int? hotelSearchId = null)
        {
            var result = await _service.GetAllHotelsAsync(hotelSearchId);
            return Ok(result);
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> GetHotelById(int hotelId)
        {
            var result = await _service.GetHotelByIdAsync(hotelId);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
        #endregion

        #region Hotel Offers

        [HttpPost("offers")]
        public async Task<IActionResult> AddHotelOffer([FromBody] HotelOfferDto dto)
        {
            var result = await _service.AddHotelOfferAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetHotelOffers), new { }, result);
        }

        [HttpGet("offers")]
        public async Task<IActionResult> GetHotelOffers()
        {
            var result = await _service.GetHotelOffersAsync();
            return Ok(result);
        }

        [HttpPut("offers/{offerId}")]
        public async Task<IActionResult> UpdateHotelOffer(int offerId, [FromBody] HotelOfferDto dto)
        {
            var result = await _service.UpdateHotelOfferAsync(offerId, dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("offers/{offerId}")]
        public async Task<IActionResult> DeleteHotelOffer(int offerId)
        {
            var result = await _service.DeleteHotelOfferAsync(offerId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        #endregion

        #region Daily Deals

        [HttpPost("daily-deals")]
        public async Task<IActionResult> AddDailyDeal([FromBody] DailyStealDealDto dto)
        {
            var result = await _service.AddDailyDealAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetDailyDeals), new { }, result);
        }

        [HttpGet("daily-deals")]
        public async Task<IActionResult> GetDailyDeals()
        {
            var result = await _service.GetDailyDealsAsync();
            return Ok(result);
        }

        [HttpGet("daily-deals/{dealId}")]
        public async Task<IActionResult> GetDailyDealById(int dealId)
        {
            var result = await _service.GetDailyDealByIdAsync(dealId);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
        #endregion

        #region Different Seasons

        [HttpPost("seasons")]
        public async Task<IActionResult> AddSeason([FromBody] DifferentSeasonDto dto)
        {
            var result = await _service.AddSeasonAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetSeasons), new { }, result);
        }

        [HttpGet("seasons")]
        public async Task<IActionResult> GetSeasons()
        {
            var result = await _service.GetSeasonsAsync();
            return Ok(result);
        }

        [HttpPut("seasons/{seasonId}")]
        public async Task<IActionResult> UpdateSeason(int seasonId, [FromBody] DifferentSeasonDto dto)
        {
            var result = await _service.UpdateSeasonAsync(seasonId, dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("seasons/{seasonId}")]
        public async Task<IActionResult> DeleteSeason(int seasonId)
        {
            var result = await _service.DeleteSeasonAsync(seasonId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        #endregion

        #region Popular Destinations

        [HttpPost("popular-destinations")]
        public async Task<IActionResult> AddPopularDestination([FromBody] PopularDestinationDto dto)
        {
            var result = await _service.AddPopularDestinationAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetPopularDestinations), new { }, result);
        }

        [HttpGet("popular-destinations")]
        public async Task<IActionResult> GetPopularDestinations()
        {
            var result = await _service.GetPopularDestinationsAsync();
            return Ok(result);
        }

        [HttpDelete("popular-destinations/{destinationId}")]
        public async Task<IActionResult> DeletePopularDestination(int destinationId)
        {
            var result = await _service.DeletePopularDestinationAsync(destinationId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        #endregion

        #region FAQs

        [HttpPost("faqs")]
        public async Task<IActionResult> AddHotelFaq([FromBody] HotelFaqDto dto)
        {
            var result = await _service.AddHotelFaqAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction(nameof(GetHotelFaqs), new { }, result);
        }

        [HttpGet("faqs")]
        public async Task<IActionResult> GetHotelFaqs()
        {
            var result = await _service.GetHotelFaqsAsync();
            return Ok(result);
        }
        #endregion
    }
}