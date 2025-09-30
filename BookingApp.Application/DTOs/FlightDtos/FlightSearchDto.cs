
using System;
using System.Text.Json.Serialization;


namespace BookingApp.Application.DTOs.FlightDtos
{
    public class FlightSearchDto
    {
       
        public string Source { get; set; }
        public string Destination { get; set; }

        
        public DateTime? Depart_Date { get; set; }

        
        public DateTime? Return_Date { get; set; }

        public string Trip_Type { get; set; }
        public string Passenger_Type { get; set; }
        public string Travel_Class { get; set; }
        public string Fare_Type { get; set; }
    }
}
