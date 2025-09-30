using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelPolicyRepository
    {
        Task<int> AddpolicyAsync(CreateHotelPolicyDto dto);

        Task<int> UpdatePolicyAsync(int policyId, CreateHotelPolicyDto dto);

        Task<int> DeletePolicyAsync(int policyId);

        Task<IEnumerable<HotelPolicy>> GetAllPolicyAsync();

        Task<HotelPolicy> GetPolicyByIdAsync(int policyId);
    }
}
