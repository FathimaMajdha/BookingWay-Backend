using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;


namespace BookingApp.Infrastructure.Services.Admin
{
    
        public class AdminAmenityService : IAdminAmenityService
    {
            private readonly IAdminAmenitiesRepository _repo;

            public AdminAmenityService(IAdminAmenitiesRepository repo)
            {
                _repo = repo;
            }

            public async Task<ApiResponse<int>> AddAmenityAsync(AdminAmenityDto dto)
            {
                try
                {
                    var result = await _repo.AddHotelAmenityAsync(dto);
                    return ApiResponse<int>.SuccessResponse(result, "Amenity added successfully.");
                }
                catch (Exception ex)
                {
                    return ApiResponse<int>.FailResponse($"Error adding amenity: {ex.Message}");
                }
            }

            public async Task<ApiResponse<int>> UpdateAmenityAsync(int amenityId, AdminAmenityDto dto)
            {
                try
                {
                    var result = await _repo.UpdateHotelAmenityAsync(amenityId, dto);
                    return ApiResponse<int>.SuccessResponse(result, "Amenity updated successfully.");
                }
                catch (Exception ex)
                {
                    return ApiResponse<int>.FailResponse($"Error updating amenity: {ex.Message}");
                }
            }

            public async Task<ApiResponse<int>> DeleteAmenityAsync(int amenityId)
            {
                try
                {
                    var result = await _repo.DeleteHotelAmenityAsync(amenityId);
                    return ApiResponse<int>.SuccessResponse(result, "Amenity deleted successfully.");
                }
                catch (Exception ex)
                {
                    return ApiResponse<int>.FailResponse($"Error deleting amenity: {ex.Message}");
                }
            }

            public async Task<ApiResponse<IEnumerable<AdminAmenity>>> GetAllAmenitysAsync(int? hotelId = null)
            {
                try
                {
                    var result = await _repo.GetAllHotelAmenityAsync(hotelId);
                    return ApiResponse<IEnumerable<AdminAmenity>>.SuccessResponse(result, "Amenities fetched successfully.");
                }
                catch (Exception ex)
                {
                    return ApiResponse<IEnumerable<AdminAmenity>>.FailResponse($"Error fetching amenities: {ex.Message}");
                }
            }

            public async Task<ApiResponse<AdminAmenity?>> GetAmenityByIdAsync(int amenityId)
            {
                try
                {
                    var result = await _repo.GetHotelAmenityByIdAsync(amenityId);
                    if (result == null)
                        return ApiResponse<AdminAmenity?>.FailResponse("Amenity not found.");

                    return ApiResponse<AdminAmenity?>.SuccessResponse(result, "Amenity fetched successfully.");
                }
                catch (Exception ex)
                {
                    return ApiResponse<AdminAmenity?>.FailResponse($"Error fetching amenity: {ex.Message}");
                }
            }

       
    }
    
}

