using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class AdminFlightFareDto
    {
        public int FlightId { get; set; }
        public string FareName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Baggage { get; set; } = string.Empty;
        public string Refund { get; set; } = string.Empty;
        public string ChangeFee { get; set; } = string.Empty;
        public string Meals { get; set; } = string.Empty;
    }

   
}