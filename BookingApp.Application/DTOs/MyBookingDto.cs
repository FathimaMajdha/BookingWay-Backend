
namespace BookingApp.Application.DTOs
{
    public class MyBookingDto
    {
        public int MyBookingId { get; set; }
        public string Type { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }

        
        public int? Flight_Booking_Id { get; set; }
        public string? AirlineName { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerEmail { get; set; }
        public string? PassengerPhone { get; set; }
        public string? PassengerType { get; set; }

       
        public int? Hotel_Booking_Id { get; set; }
        public int? HotelId { get; set; }
        public string? HotelName { get; set; }
        public int? RoomId { get; set; }
        public string? GuestName { get; set; }
        public string? GuestEmail { get; set; }
        public string? GuestPhone { get; set; }
        public string? Hotel_Name { get; set; }
        public string? City { get; set; }
        public string? Room_Type { get; set; }
        public decimal? RoomPrice { get; set; }
    }
}