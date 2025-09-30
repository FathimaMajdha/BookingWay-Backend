using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class Amenity
    {
        public int AmenityId { get; set; }
        public string Amenity_Name { get; set; }
        public string Amenities_Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}
