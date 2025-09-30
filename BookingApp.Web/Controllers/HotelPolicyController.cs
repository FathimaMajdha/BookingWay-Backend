using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelPolicyController : ControllerBase
    {
        private readonly IHotelPolicyService _service;

        public HotelPolicyController(IHotelPolicyService service)
        {
            _service = service;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPolicy([FromBody] CreateHotelPolicyDto dto)
        {
            var result = await _service.AddpolicyAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{policyId}")]
        public async Task<IActionResult> UpdatePolicy(int policyId, [FromBody] CreateHotelPolicyDto dto)
        {

            var updated = await _service.UpdatePolicyAsync(policyId, dto);
            return Ok(updated);
        }

        [HttpDelete("delete/{policyId}")]
        public async Task<IActionResult> DeletePolicy(int policyId)
        {
            await _service.DeletePolicyAsync(policyId);
            return Ok(new { message = "Amenity deleted successfully." });
        }



        [HttpGet]
        public async Task<IActionResult> GetAllPolicy()
        {
            var policies = await _service.GetAllPolicyAsync();
            return Ok(policies);
        }

        [HttpGet("{policyId}")]
        public async Task<IActionResult> GetpolicyById(int policyId)
        {
            var policy = await _service.GetPolicyByIdAsync(policyId);
            return Ok(policy);
        }
    }
}
