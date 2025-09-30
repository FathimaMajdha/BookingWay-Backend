using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.HotelPropertyDto
{
    public class CreateHotelLocationDto
    {
        public int HotelId { get; set; }
        public string Address { get; set; }
        public string NearbyLandmarks { get; set; }
        public string MapUrl { get; set; }
        public string EmbedUrl { get; set; }
       
    }
}
