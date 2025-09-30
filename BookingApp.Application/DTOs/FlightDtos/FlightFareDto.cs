using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.FlightDtos
{
    public class FlightFareDto
    {
        public int FlightId { get; set; }
        public string FareName { get; set; }
        public int Price { get; set; }
        public string Baggage { get; set; }
        public string Refund { get; set; }
        public string ChangeFee { get; set; }
        public string Meals { get; set; }
    }
}
