using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminOverviewRepository
    {
        Task<DashboardOverview> GetOverviewAsync();
        Task<IEnumerable<RevenueUser>> GetRevenueByUserAsync();
        Task<IEnumerable<BookingsPerUser>> GetBookingsPerUserAsync();
        Task<IEnumerable<DailyRevenue>> GetDailyRevenueTrendAsync();
        Task<IEnumerable<RecentActivity>> GetRecentActivitiesAsync();
        Task<IEnumerable<Top>> GetTopHotelsAsync();
        Task<IEnumerable<Top>> GetTopFlightsAsync();
        Task<IEnumerable<Offer>> GetHotelOffersAsync();
        Task<IEnumerable<Offer>> GetFlightOffersAsync();
    }
}
