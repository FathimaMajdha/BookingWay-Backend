using BookingApp.Application.DTOs.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminSimilarPropertyRepository
    {
        Task<int> AddSimilarPropAsync(AdminSimilarPropertyDto dto);
        Task<int> UpdateSimilarPropAsync(int propId, AdminSimilarPropertyDto dto);
        Task<int> DeleteSimilarPropAsync(int propId);
        Task<IEnumerable<AdminSimilarProperty>> GetAllSimilarPropAsync();
        Task<AdminSimilarProperty> GetSimilarPropByIdAsync(int propId);
        Task<IEnumerable<AdminSimilarPropertyDto>> GetSimilarPropertiesAsync(int hotelId);
          
    }
}
