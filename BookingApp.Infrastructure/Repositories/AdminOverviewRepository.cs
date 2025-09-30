using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookingApp.Infrastructure.Repositories
{
    public class AdminOverviewRepository : IAdminOverviewRepository
    {
        private readonly IDbConnection _conn;

        public AdminOverviewRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<DashboardOverview> GetOverviewAsync()
        {
            return await _conn.QueryFirstOrDefaultAsync<DashboardOverview>(
                "sp_DashboardOverview",
                new { Flag = 1 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<RevenueUser>> GetRevenueByUserAsync()
        {
            return await _conn.QueryAsync<RevenueUser>(
                "sp_DashboardOverview",
                new { Flag = 2 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<BookingsPerUser>> GetBookingsPerUserAsync()
        {
            return await _conn.QueryAsync<BookingsPerUser>(
                "sp_DashboardOverview",
                new { Flag = 3 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<DailyRevenue>> GetDailyRevenueTrendAsync()
        {
            return await _conn.QueryAsync<DailyRevenue>(
                "sp_DashboardOverview",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<RecentActivity>> GetRecentActivitiesAsync()
        {
            return await _conn.QueryAsync<RecentActivity>(
                "sp_DashboardOverview",
                new { Flag = 5 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Top>> GetTopHotelsAsync()
        {
            return await _conn.QueryAsync<Top>(
                "sp_DashboardOverview",
                new { Flag = 6 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Top>> GetTopFlightsAsync()
        {
            return await _conn.QueryAsync<Top>(
                "sp_DashboardOverview",
                new { Flag = 7 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Offer>> GetHotelOffersAsync()
        {
            return await _conn.QueryAsync<Offer>(
                "sp_DashboardOverview",
                new { Flag = 8 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<Offer>> GetFlightOffersAsync()
        {
            return await _conn.QueryAsync<Offer>(
                "sp_DashboardOverview",
                new { Flag = 9 },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
