using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
   public class HotelLocation
    {
      public int  LocationId { get; set; }
      public int HotelId { get; set; }
      public string  Address { get; set; }
      public string   NearbyLandmarks { get; set; }
      public string  MapUrl { get; set; }
      public string  EmbedUrl { get; set; }
        public DateTime Created_At { get; set; }
    }
}
