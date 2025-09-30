using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.FlightDtos
{
    public class CreateOrderDto
    {
        public decimal Amount { get; set; }
        public int BookingId { get; set; }
    }
}
