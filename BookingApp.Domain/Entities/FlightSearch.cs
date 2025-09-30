using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class FlightSearch
    {
        public int FlightSearchId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Depart_Date { get; set; }
        public DateTime? Return_Date { get; set; }
        public string Trip_Type { get; set; }
        public string Passenger_Type { get; set; }
        public string Travel_Class { get; set; }
        public string Fare_Type { get; set; }
        public DateTime Created_At { get; set; }
    }
}
