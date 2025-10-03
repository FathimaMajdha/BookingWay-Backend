using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Application.DTOs.Admin;

namespace BookingApp.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationRequestDto request)
        {
            var result = await _userManagementService.GetUsersAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("block/{id}")]
        public async Task<IActionResult> BlockUser(int id)
        {
            var result = await _userManagementService.BlockUserAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("unblock/{id}")]
        public async Task<IActionResult> UnblockUser(int id)
        {
            var result = await _userManagementService.UnblockUserAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userManagementService.DeleteUserAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}