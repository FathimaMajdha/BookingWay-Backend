using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class FlightDto
    {
        public int FlightSearchId { get; set; }
        public int Passenger_Count { get; set; }
        public string Airline_Name { get; set; }
        public string IATA_Code { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Depart_DateTime { get; set; }
        public string Depart_Place { get; set; }
        public DateTime Arrival_DateTime { get; set; }
        public string Arrival_Place { get; set; }
        public decimal Base_Fare { get; set; }
        public string TravelClass { get; set; }

        public int Depart_Duration { get; set; }

        
        public string Airline_Icon { get; set; } = "default.png"; 
    }
}
