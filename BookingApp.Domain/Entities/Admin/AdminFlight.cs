using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminFlight
    {
        public int FlightId { get; set; }
        public int FlightSearchId { get; set; }
        public string Airline_Name { get; set; }
        public string Airline_Icon { get; set; }
        public string IATA_Code { get; set; }
        public string FlightNumber { get; set; }
        public string Depart_Place { get; set; }
        public string Arrival_Place { get; set; }
        public DateTime Depart_DateTime { get; set; }
        public DateTime Arrival_DateTime { get; set; }
        public string TravelClass { get; set; }
        public decimal Base_Fare { get; set; }
        public string Baggage { get; set; }
        public string Cabin { get; set; }
        public string CheckIn { get; set; }
        public bool IsRefundable { get; set; }

        public int Passenger_Count { get; set; }

        public string Depart_Duration { get; set; }

        public DateTime Created_At { get; set; }
    }
}
