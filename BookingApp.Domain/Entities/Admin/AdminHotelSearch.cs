using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminHotelSearch
    {
        public int HotelSearchId { get; set; }
        public string Location { get; set; } = null!;
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Guest_Type { get; set; } = null!;
        public int Guest_Count { get; set; }
        public string Room_Count { get; set; } = null!;
        public DateTime Created_At { get; set; }
    }
}
