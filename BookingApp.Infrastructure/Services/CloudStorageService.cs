using BookingApp.Application.Common;
using BookingApp.Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class CloudStorageService : ICloudStorageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudStorageService(IConfiguration config)
        {
            var account = new Account(
                config["Cloudinary:CloudName"],
                config["Cloudinary:ApiKey"],
                config["Cloudinary:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ApiResponse<string>> UploadImageAsync(IFormFile file, string folder = null)
        {
            if (file == null || file.Length == 0)
                return ApiResponse<string>.FailResponse("No file provided for upload.");

            try
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    Folder = folder
                };

                var result = await _cloudinary.UploadAsync(uploadParams);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return ApiResponse<string>.SuccessResponse(result.SecureUrl.ToString(), "Image uploaded successfully.");

                return ApiResponse<string>.FailResponse($"Image upload failed: {result.Error?.Message}");
            }
            catch (Exception ex)
            {
                return ApiResponse<string>.FailResponse($"Image upload exception: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteImageAsync(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return ApiResponse<bool>.FailResponse("No image URL provided for deletion.");

            try
            {
                var publicId = System.IO.Path.GetFileNameWithoutExtension(imageUrl);
                var deletionParams = new DeletionParams(publicId);
                var result = await _cloudinary.DestroyAsync(deletionParams);

                if (result.Result == "ok")
                    return ApiResponse<bool>.SuccessResponse(true, "Image deleted successfully.");

                return ApiResponse<bool>.FailResponse($"Image deletion failed: {result.Error?.Message}");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.FailResponse($"Image deletion exception: {ex.Message}");
            }
        }
    }
}
