using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Infrastructure.Services.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    [Route("api/admin/hotelpolicy")]
    [ApiController]
    public class AdminHotelPolicyController : ControllerBase
    {

            private readonly IAdminHotelPolicyService _service;

            public AdminHotelPolicyController(IAdminHotelPolicyService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> Addpolicy([FromBody] AdminHotelPolicyDto dto)
            {
                var id = await _service.AddHotelpolicyAsync(dto);
                return Ok(id);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Updatepolicy(int id, [FromBody] AdminHotelPolicyDto dto)
            {
                var rows = await _service.UpdateHotelpolicyAsync(id, dto);
                return Ok(rows);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Deletepolicy(int id)
            {
                var rows = await _service.DeleteHotelpolicyAsync(id);
                return Ok(rows);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllPolicies([FromQuery] int? hotelId)
            {
                var list = await _service.GetAllHotelPolicyAsync(hotelId);
                return Ok(list);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetpolicyById(int id)
            {
                var item = await _service.GetHotelPolicyByIdAsync(id);
                return Ok(item);
            }
        
    }
}
