using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminAmenity
    {
        public int HotelId { get; set; }
        public int AmenityId { get; set; }
        public string Amenity_Name { get; set; } = null!;
        public string Amenities_Description { get; set; } = null!;
        public DateTime Created_At { get; set; }
    }
}
