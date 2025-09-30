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
    public interface IHotelPolicyService
    {


        Task<ApiResponse<int>> AddpolicyAsync(CreateHotelPolicyDto dto);
        Task<ApiResponse<int>> UpdatePolicyAsync(int policyId, CreateHotelPolicyDto dto);

        Task<ApiResponse<int>> DeletePolicyAsync(int policyId);
        Task<ApiResponse<IEnumerable<HotelPolicy>>> GetAllPolicyAsync();
        Task<ApiResponse<HotelPolicy?>> GetPolicyByIdAsync(int policyId);
         
    }
}
