using BookingApp.Application.Common;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminOverviewService
    {
        Task<ApiResponse<DashboardOverview>> GetOverviewAsync();
        Task<ApiResponse<IEnumerable<RevenueUser>>> GetRevenueByUserAsync();
        Task<ApiResponse<IEnumerable<BookingsPerUser>>> GetBookingsPerUserAsync();
        Task<ApiResponse<IEnumerable<DailyRevenue>>> GetDailyRevenueTrendAsync();
        Task<ApiResponse<IEnumerable<RecentActivity>>> GetRecentActivitiesAsync();
        Task<ApiResponse<IEnumerable<Top>>> GetTopHotelsAsync();
        Task<ApiResponse<IEnumerable<Top>>> GetTopFlightsAsync();
        Task<ApiResponse<IEnumerable<Offer>>> GetHotelOffersAsync();
        Task<ApiResponse<IEnumerable<Offer>>> GetFlightOffersAsync();
          
    }
}
