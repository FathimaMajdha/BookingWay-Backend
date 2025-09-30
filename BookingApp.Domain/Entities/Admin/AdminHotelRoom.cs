using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminHotelRoom
    {
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public int AmenityId { get; set; }

        public string Room_Image { get; set; }
        public string Room_Type { get; set; } = null!;
        public decimal Price { get; set; }
        public int Reviews_Count { get; set; }
        public string Reviews_Description { get; set; } = null!;
        public string Reviewer_Name { get; set; } = null!;
        public DateTime Review_Date { get; set; }
        public decimal Rating { get; set; }
        public int Selectroom_count { get; set; }
        public int Available_Rooms { get; set; }
        public int MaximumGuest_Count { get; set; }
        public int Sqft { get; set; }
        public int Bed_Count { get; set; }
        public int Bathroom_Count { get; set; }
        public string Room_Facility_Description { get; set; } = null!;
        public DateTime Created_At { get; set; }
    }
}
