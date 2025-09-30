using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookingApp.Api.Controllers

{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;

        }


        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromForm] UserProfileDto user)
        {
            try
            {
                var userAuthId = int.Parse(User.Claims.First(c => c.Type == "UserAuthId").Value);
                var userId = await _userProfileService.AddUserAsync(user, userAuthId);
                return Ok(new { UserId = userId, Message = "User Profile added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromForm] UserProfileDto user)
        {
            try
            {
                var updatedUserId = await _userProfileService.UpdateUserAsync(userId, user);
                return Ok(new { UserId = updatedUserId, Message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }



        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                var userAuthIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAuthId");
                if (userAuthIdClaim == null)
                    return Unauthorized(new { Message = "User authentication claim missing." });

                var userAuthId = int.Parse(userAuthIdClaim.Value);
                var deletedUserAuthId = await _userProfileService.DeleteUserAsync(userAuthId);

                return Ok(new { UserAuthId = deletedUserAuthId, Message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userProfileService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                var userAuthIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserAuthId");
                if (userAuthIdClaim == null)
                    return Unauthorized(new { Message = "User authentication claim missing." });

                var userAuthId = int.Parse(userAuthIdClaim.Value);
                var user = await _userProfileService.GetByAuthIdAsync(userAuthId);

                if (user == null)
                    return NotFound(new { Message = "User profile not found." });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


    }
}
