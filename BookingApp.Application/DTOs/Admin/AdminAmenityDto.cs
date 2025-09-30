using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class AdminAmenityDto
    {
        public int HotelId { get; set; }
        public string Amenity_Name { get; set; } = null!;
        public string Amenities_Description { get; set; } = null!;
    }
}
