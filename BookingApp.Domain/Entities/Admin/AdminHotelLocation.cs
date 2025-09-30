using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminHotelLocation
    {
        public int LocationId { get; set; }
        public int HotelId { get; set; }
        public string Address { get; set; } = null!;
        public string NearbyLandmarks { get; set; } = null!;
        public string MapUrl { get; set; } = null!;
        public string EmbedUrl { get; set; } = null!;
        public DateTime Created_At { get; set; }
    }
}
