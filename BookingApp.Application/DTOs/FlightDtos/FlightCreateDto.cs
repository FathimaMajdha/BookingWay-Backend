using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.FlightDtos
{
    public class FlightCreateDto
    {
        public int FlightSearchId { get; set; }
        public int Passenger_Count { get; set; }
        public string Passenger_Type { get; set; }


        public string Airline_Name { get; set; }
        public string? Airline_Icon { get; set; }
        public string IATA_Code { get; set; }
        public string FlightNumber { get; set; }
        public string? Aircraft_Type { get; set; }


        public DateTime Depart_DateTime { get; set; }
        public string Depart_Place { get; set; }
        public string Depart_Duration { get; set; }
        public string? Terminal { get; set; }
        public string? Baggage { get; set; }
        public string? Checkin { get; set; }
        public string? CABIN { get; set; }


        public DateTime Arrival_DateTime { get; set; }
        public string Arrival_Place { get; set; }


        public DateTime? Return_Depart_DateTime { get; set; }
        public string Return_Depart_Place { get; set; }
        public string Return_Duration { get; set; }
        public DateTime? Return_Arrival_DateTime { get; set; }
        public string Return_Arrival_Place { get; set; }


        public decimal Base_Fare { get; set; }
        public string Currency { get; set; }


        public bool IsRefundable { get; set; }
        public int Stops { get; set; }
        public string TravelClass { get; set; }

        public string Fare_Type { get; set; }
    }

    

}
