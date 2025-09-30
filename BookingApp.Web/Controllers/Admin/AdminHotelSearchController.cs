using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Controllers.Admin
{
    
        [Route("api/admin/hotel-search")]
        [ApiController]
        public class AdminHotelSearchController : ControllerBase
        {
            private readonly IAdminHotelSearchService _service;

            public AdminHotelSearchController(IAdminHotelSearchService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> Add([FromBody] AdminHotelSearchDto dto)
            {
                var id = await _service.AddHotelSearchAsync(dto);
                return Ok(id);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] AdminHotelSearchDto dto)
            {
                var rows = await _service.UpdateHotelSearchAsync(id, dto);
                return Ok(rows);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var rows = await _service.DeleteHotelSearchAsync(id);
                return Ok(rows);
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var list = await _service.GetAllHotelSearchesAsync();
                return Ok(list);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var item = await _service.GetHotelSearchByIdAsync(id);
                return Ok(item);
            }
        }
    

}
