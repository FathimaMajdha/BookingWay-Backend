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
    public interface IAdminHotelPolicyRepository
    {

        Task<int> AddHotelPolicyAsync(AdminHotelPolicyDto dto);
        Task<int> UpdateHotelPolicyAsync(int policyId, AdminHotelPolicyDto dto);
        Task<int> DeleteHotelPolicyAsync(int policyId);
        Task<IEnumerable<AdminHotelPolicy>> GetAllHotelPolicyAsync(int? hotelId = null);
        Task<AdminHotelPolicy?> GetHotelPolicyByIdAsync(int policyId);
        

    }
}
