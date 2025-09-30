using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IAmenityService
    {

        Task<ApiResponse<int>> AddAmenityAsync(AmenityDto dto);
        Task<ApiResponse<int>> UpdateAmenityAsync(int amenityId, AmenityDto dto);
        Task<ApiResponse<int>> DeleteAmenityAsync(int amenityId);
        Task<ApiResponse<IEnumerable<Amenity>>> GetAllAmenitiesAsync();
        Task<ApiResponse<Amenity?>> GetAmenityByIdAsync(int amenityId);
         
    }

}

