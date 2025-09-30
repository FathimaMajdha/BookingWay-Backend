using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class FlightBooking
    {
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public int FareId { get; set; }
        public int? UserAuthId { get; set; }
        public string? AirlineName { get; set; }

        public string PassengerName { get; set; } = null!;
        public string PassengerEmail { get; set; } = null!;
        public string PassengerPhone { get; set; } = null!;
        public string PassengerType { get; set; } = "Adult";
        public string? Meals { get; set; }

        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
        public string? RazorpayOrderId { get; set; }
        public string? RazorpayPaymentId { get; set; }
        public string? RazorpaySignature { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
