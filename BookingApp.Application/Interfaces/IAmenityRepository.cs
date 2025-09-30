using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IAmenityRepository
    {
        Task<int> AddAmenityAsync(AmenityDto dto);
        Task<int> UpdateAmenityAsync(int amenityId, AmenityDto dto);
        Task<int> DeleteAmenityAsync(int amenityId);
        Task<IEnumerable<Amenity>> GetAllAmenitiesAsync();
        Task<Amenity> GetAmenityByIdAsync(int amenityId);
    }
}
