using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface ISimilarPropertyService
    {

        Task<ApiResponse<int>> AddpropAsync(SimilarPropertyDto dto);
        Task<ApiResponse<int>> UpdatepropAsync(int propId, SimilarPropertyDto dto);
        Task<ApiResponse<int>> DeletepropAsync(int propId);
        Task<ApiResponse<IEnumerable<SimilarProperty>>> GetAllpropsAsync();
        Task<ApiResponse<SimilarProperty?>> GetpropByIdAsync(int propId);
        Task<ApiResponse<IEnumerable<SimilarPropertyDto>>> GetSimilarPropertiesAsync(int hotelId);
           
    }
}
