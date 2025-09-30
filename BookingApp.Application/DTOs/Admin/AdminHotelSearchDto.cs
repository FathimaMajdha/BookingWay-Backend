using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class AdminHotelSearchDto
    {
        public string Location { get; set; } = null!;
        public string Checkin { get; set; } = null!;
        public string Checkout { get; set; } = null!;
        public string Guest_Type { get; set; } = null!;
        public int Guest_Count { get; set; }
        public string Room_Count { get; set; } = null!;
    }
}
