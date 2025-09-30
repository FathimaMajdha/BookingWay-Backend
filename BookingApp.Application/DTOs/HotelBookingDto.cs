using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTO
{
    public class HotelBookingDto
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int? UserAuthId { get; set; }
        public string? HotelName { get; set; }

        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string GuestPhone { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;
        public string? PaymentStatus { get; set; }
        public string? RazorpayOrderId { get; set; }
        public string? RazorpayPaymentId { get; set; }
        public string? RazorpaySignature { get; set; }
    }
}
