using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
   public class AdminBooking
    {

        public int UserAuthId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int MyBookingId { get; set; }
        public string BookingType { get; set; }         
        public string BookingTypeName { get; set; }     
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BookingDate { get; set; }

        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhone { get; set; }
        public string PassengerType { get; set; }
        public string HotelName { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }

    }
}
