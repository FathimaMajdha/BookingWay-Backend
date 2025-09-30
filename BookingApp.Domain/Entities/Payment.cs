using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Payment_Status { get; set; } 
        public DateTime Payment_Date { get; set; }
        public string Booking_Type { get; set; } 
        public string Payment_Method { get; set; } 


    }
}
