


using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities.Admin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminAmenityService
    {
        Task<ApiResponse<int>> AddAmenityAsync(AdminAmenityDto dto);
        Task<ApiResponse<int>> UpdateAmenityAsync(int amenityId, AdminAmenityDto dto);
        Task<ApiResponse<int>> DeleteAmenityAsync(int amenityId);
        Task<ApiResponse<IEnumerable<AdminAmenity>>> GetAllAmenitysAsync(int? hotelId = null);
        Task<ApiResponse<AdminAmenity?>> GetAmenityByIdAsync(int amenityId);
    }
}
