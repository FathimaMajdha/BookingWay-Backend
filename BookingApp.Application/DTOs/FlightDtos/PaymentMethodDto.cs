using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.FlightDtos
{
    public class PaymentMethodDto
    {
        public int BookingId { get; set; }
        public string Payment_Method { get; set; }
    }

}
