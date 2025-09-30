using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface ISimilarPropertyRepository
    {
        Task<int> AddSimilarPropAsync(SimilarPropertyDto dto);

        Task<int> UpdateSimilarPropAsync(int propId, SimilarPropertyDto dto);

        Task<int> DeleteSimilarPropAsync(int propId);

        Task<IEnumerable<SimilarProperty>> GetAllSimilarPropAsync();

        Task<SimilarProperty> GetSimilarPropByIdAsync(int propId);

        Task<IEnumerable<SimilarPropertyDto>> GetSimilarPropertiesAsync(int hotelId);
    }
}
