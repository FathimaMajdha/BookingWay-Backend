using BookingApp.Application.Common;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminOverviewService : IAdminOverviewService
    {
        private readonly IAdminOverviewRepository _repo;

        public AdminOverviewService(IAdminOverviewRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<DashboardOverview>> GetOverviewAsync()
        {
            try
            {
                var result = await _repo.GetOverviewAsync();
                return ApiResponse<DashboardOverview>.SuccessResponse(result, "Dashboard overview fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<DashboardOverview>.FailResponse($"Error fetching dashboard overview: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<RevenueUser>>> GetRevenueByUserAsync()
        {
            try
            {
                var result = await _repo.GetRevenueByUserAsync();
                return ApiResponse<IEnumerable<RevenueUser>>.SuccessResponse(result, "Revenue by user fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<RevenueUser>>.FailResponse($"Error fetching revenue by user: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<BookingsPerUser>>> GetBookingsPerUserAsync()
        {
            try
            {
                var result = await _repo.GetBookingsPerUserAsync();
                return ApiResponse<IEnumerable<BookingsPerUser>>.SuccessResponse(result, "Bookings per user fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<BookingsPerUser>>.FailResponse($"Error fetching bookings per user: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<DailyRevenue>>> GetDailyRevenueTrendAsync()
        {
            try
            {
                var result = await _repo.GetDailyRevenueTrendAsync();
                return ApiResponse<IEnumerable<DailyRevenue>>.SuccessResponse(result, "Daily revenue trend fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<DailyRevenue>>.FailResponse($"Error fetching daily revenue trend: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<RecentActivity>>> GetRecentActivitiesAsync()
        {
            try
            {
                var result = await _repo.GetRecentActivitiesAsync();
                return ApiResponse<IEnumerable<RecentActivity>>.SuccessResponse(result, "Recent activities fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<RecentActivity>>.FailResponse($"Error fetching recent activities: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Top>>> GetTopHotelsAsync()
        {
            try
            {
                var result = await _repo.GetTopHotelsAsync();
                return ApiResponse<IEnumerable<Top>>.SuccessResponse(result, "Top hotels fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Top>>.FailResponse($"Error fetching top hotels: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Top>>> GetTopFlightsAsync()
        {
            try
            {
                var result = await _repo.GetTopFlightsAsync();
                return ApiResponse<IEnumerable<Top>>.SuccessResponse(result, "Top flights fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Top>>.FailResponse($"Error fetching top flights: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Offer>>> GetHotelOffersAsync()
        {
            try
            {
                var result = await _repo.GetHotelOffersAsync();
                return ApiResponse<IEnumerable<Offer>>.SuccessResponse(result, "Hotel offers fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Offer>>.FailResponse($"Error fetching hotel offers: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<Offer>>> GetFlightOffersAsync()
        {
            try
            {
                var result = await _repo.GetFlightOffersAsync();
                return ApiResponse<IEnumerable<Offer>>.SuccessResponse(result, "Flight offers fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Offer>>.FailResponse($"Error fetching flight offers: {ex.Message}");
            }
        }
    }
}
