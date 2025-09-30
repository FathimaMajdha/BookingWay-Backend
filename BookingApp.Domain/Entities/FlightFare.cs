using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class FlightFare
    {
       public int FareId { get; set; }
        public int FlightId { get; set; }
        public string FareName { get; set; }
        public int Price { get; set; }
       public string Baggage { get; set; }
       public string Refund { get; set; }
       public string ChangeFee { get; set; }
        public string Meals { get; set; }
        public DateTime Created_At { get; set; }
    }
}
