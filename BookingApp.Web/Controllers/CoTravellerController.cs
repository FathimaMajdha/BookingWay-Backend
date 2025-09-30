using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CoTravellerController : ControllerBase
    {
        private readonly ICoTravellerService _coTravellerService;

        public CoTravellerController(ICoTravellerService coTravellerService)
        {
            _coTravellerService = coTravellerService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCoTraveller( CoTravellerDto traveller)
        {
            try
            {
                var userAuthIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAuthId");
                if (userAuthIdClaim == null)
                    return Unauthorized(new { Message = "User authentication claim missing." });

                var userAuthId = int.Parse(userAuthIdClaim.Value);
                await _coTravellerService.AddCoTravellerAsync(userAuthId, traveller);

                return Ok(new { Message = "CoTraveller added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("update/{coTravellerId}")]
        public async Task<IActionResult> UpdateCoTraveller(int coTravellerId, CoTravellerDto traveller)
        {
            try
            {
                await _coTravellerService.UpdateCoTravellerAsync(coTravellerId, traveller);
                return Ok(new { Message = "CoTraveller updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("delete/{coTravellerId}")]
        public async Task<IActionResult> DeleteCoTraveller(int coTravellerId)
        {
            try
            {
                await _coTravellerService.DeleteCoTravellerAsync(coTravellerId);
                return Ok(new { Message = "CoTraveller deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCoTravellers()
        {
            try
            {
                var coTravellers = await _coTravellerService.GetAllCoTravellersAsync();
                return Ok(coTravellers);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{coTravellerId}")]
        public async Task<IActionResult> GetCoTravellerById(int coTravellerId)
        {
            try
            {
                var coTraveller = await _coTravellerService.GetCoTravellersByIdAsync(coTravellerId);

                if (coTraveller == null)
                    return NotFound(new { Message = "CoTraveller not found." });

                return Ok(coTraveller);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
