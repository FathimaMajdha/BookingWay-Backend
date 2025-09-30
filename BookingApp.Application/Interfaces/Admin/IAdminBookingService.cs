using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminBookingService
    {
        Task<ApiResponse<IEnumerable<AdminBookingDto>>> GetAllAdminBookingsAsync();
    }
}
