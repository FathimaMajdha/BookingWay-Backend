using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminSimilarPropertyService
    {
        Task<ApiResponse<int>> AddpropAsync(AdminSimilarPropertyDto dto);
        Task<ApiResponse<int>> UpdatepropAsync(int propId, AdminSimilarPropertyDto dto);
        Task<ApiResponse<int>> DeletepropAsync(int propId);
        Task<ApiResponse<IEnumerable<AdminSimilarProperty>>> GetAllpropsAsync();
        Task<ApiResponse<AdminSimilarProperty?>> GetpropByIdAsync(int propId);
        Task<ApiResponse<IEnumerable<AdminSimilarPropertyDto>>> GetSimilarPropertiesAsync(int hotelId);


    }
}
