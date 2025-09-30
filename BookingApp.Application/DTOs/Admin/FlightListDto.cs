using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class FlightListDto
    {
        public int Id { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public string DepartPlace { get; set; }
        public string ArrivalPlace { get; set; }
        public string DepartDate { get; set; }
        public string ArrivalDate { get; set; }
        public decimal Price { get; set; }
        public string TravelClass { get; set; }

        public int Depart_Duration { get; set; }

        public string Airline_Icon { get; set; } = "default.png";
        public string CategoryName { get; set; }
    }
}
