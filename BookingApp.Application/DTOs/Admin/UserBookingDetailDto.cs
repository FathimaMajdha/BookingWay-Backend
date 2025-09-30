using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class UserBookingDetailDto
    {
        public int UserAuthId { get; set; }
        public string BookingType { get; set; }
        public int BookingId { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BookingDate { get; set; }
    }

}
