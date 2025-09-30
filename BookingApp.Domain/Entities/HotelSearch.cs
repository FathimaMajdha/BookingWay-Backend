using System;

namespace BookingApp.Domain.Entities
{
    public class HotelSearch
    {
        public int HotelSearchId { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Guest_Type { get; set; } = string.Empty;
        public int Guest_Count { get; set; }
        public int Room_Count { get; set; }
        public DateTime? Created_At { get; set; }
        public List<Hotel>? Hotels { get; set; }
    }
}