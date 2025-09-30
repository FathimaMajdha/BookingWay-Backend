using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class AdminHotelLocationDto
    {
        public int HotelId { get; set; }
        public string Address { get; set; } = null!;
        public string NearbyLandmarks { get; set; } = null!;
        public string MapUrl { get; set; } = null!;
        public string EmbedUrl { get; set; } = null!;
    }
}
