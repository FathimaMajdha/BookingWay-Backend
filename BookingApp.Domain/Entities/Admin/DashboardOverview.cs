namespace BookingApp.Domain.Entities.Admin
{
    public class DashboardOverview
    {
        public int TotalUsers { get; set; }
        public int TotalBookings { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
