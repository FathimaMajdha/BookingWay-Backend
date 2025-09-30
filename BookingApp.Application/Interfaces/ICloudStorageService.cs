using BookingApp.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface ICloudStorageService
    {
        Task<ApiResponse<string>> UploadImageAsync(IFormFile file, string folder = null);
        Task<ApiResponse<bool>> DeleteImageAsync(string imageUrl);
        
    }

}

