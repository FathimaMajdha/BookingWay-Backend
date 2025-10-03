using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingApp.Application.Interfaces;

namespace BookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CloudStorageController : ControllerBase
    {
        private readonly ICloudStorageService _cloudStorageService;

        public CloudStorageController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file, [FromQuery] string folder = null)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file provided");

            var result = await _cloudStorageService.UploadImageAsync(file, folder);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        
        [HttpPost("upload-multiple")]
        public async Task<IActionResult> UploadMultipleImages(List<IFormFile> files, [FromQuery] string folder = null)
        {
            if (files == null || files.Count == 0)
                return BadRequest("No files provided");

            var uploadResults = new List<string>();
            var errors = new List<string>();

            foreach (var file in files)
            {
                var result = await _cloudStorageService.UploadImageAsync(file, folder);
                if (result.Success)
                    uploadResults.Add(result.Data);
                else
                    errors.Add($"{file.FileName}: {result.Message}");
            }

            if (errors.Count > 0)
                return Ok(new
                {
                    Success = true,
                    Message = $"{uploadResults.Count} files uploaded successfully, {errors.Count} failed",
                    UploadedUrls = uploadResults,
                    Errors = errors
                });

            return Ok(new
            {
                Success = true,
                Message = "All files uploaded successfully",
                UploadedUrls = uploadResults
            });
        }

        
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteImage([FromQuery] string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return BadRequest("Image URL is required");

            var result = await _cloudStorageService.DeleteImageAsync(imageUrl);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}