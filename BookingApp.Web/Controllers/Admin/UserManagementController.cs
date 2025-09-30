using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("users")]
        public async Task<ActionResult<ApiResponse<PaginatedResponseDto<UserManagementDto>>>> GetUsers(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchTerm = null,
            [FromQuery] string sortColumn = "Created_At",
            [FromQuery] string sortDirection = "DESC",
            [FromQuery] string username = null,
            [FromQuery] string email = null)
        {
            var request = new PaginationRequestDto
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm,
                SortColumn = sortColumn,
                SortDirection = sortDirection,
                Username = username,
                Email = email
            };

            var result = await _userManagementService.GetUsersAsync(request);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("block/{userAuthId}")]
        public async Task<ActionResult<ApiResponse<UserActionResponseDto>>> BlockUser(int userAuthId)
        {
            var result = await _userManagementService.BlockUserAsync(userAuthId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("unblock/{userAuthId}")]
        public async Task<ActionResult<ApiResponse<UserActionResponseDto>>> UnblockUser(int userAuthId)
        {
            var result = await _userManagementService.UnblockUserAsync(userAuthId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("delete/{userAuthId}")]
        public async Task<ActionResult<ApiResponse<UserActionResponseDto>>> DeleteUser(int userAuthId)
        {
            var result = await _userManagementService.DeleteUserAsync(userAuthId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}