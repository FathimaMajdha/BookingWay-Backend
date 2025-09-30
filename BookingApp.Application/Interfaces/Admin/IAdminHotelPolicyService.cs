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
    public interface IAdminHotelPolicyService
    {

        Task<ApiResponse<int>> AddHotelpolicyAsync(AdminHotelPolicyDto dto);
        Task<ApiResponse<int>> UpdateHotelpolicyAsync(int policyId, AdminHotelPolicyDto dto);
        Task<ApiResponse<int>> DeleteHotelpolicyAsync(int policyId);
        Task<ApiResponse<IEnumerable<AdminHotelPolicy>>> GetAllHotelPolicyAsync(int? hotelId = null);
        Task<ApiResponse<AdminHotelPolicy?>> GetHotelPolicyByIdAsync(int policyId);
           
        
    }

}
