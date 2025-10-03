using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;
using BookingApp.Application.DTOs;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        // GET: api/userprofile
        [HttpGet]
        public async Task<IActionResult> GetAllUserProfiles()
        {
            var result = await _userProfileService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // GET: api/userprofile/my-profile
        [HttpGet("my-profile")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userAuthId))
                return Unauthorized("Invalid user ID in token");

            var result = await _userProfileService.GetByAuthIdAsync(userAuthId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // GET: api/userprofile/auth/5
        [HttpGet("auth/{userAuthId}")]
        public async Task<IActionResult> GetProfileByAuthId(int userAuthId)
        {
            var result = await _userProfileService.GetByAuthIdAsync(userAuthId);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/userprofile
        [HttpPost]
        public async Task<IActionResult> AddUserProfile([FromForm] UserProfileDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userAuthId))
                return Unauthorized("Invalid user ID in token");

            var result = await _userProfileService.AddUserAsync(user, userAuthId);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetMyProfile), result);
        }

        // PUT: api/userprofile
        [HttpPut]
        public async Task<IActionResult> UpdateUserProfile([FromForm] UserProfileDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userAuthId))
                return Unauthorized("Invalid user ID in token");

            var result = await _userProfileService.UpdateUserAsync(userAuthId, user);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/userprofile
        [HttpDelete]
        public async Task<IActionResult> DeleteUserProfile()
        {
            var userIdClaim = User.FindFirst("UserAuthId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userAuthId))
                return Unauthorized("Invalid user ID in token");

            var result = await _userProfileService.DeleteUserAsync(userAuthId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}