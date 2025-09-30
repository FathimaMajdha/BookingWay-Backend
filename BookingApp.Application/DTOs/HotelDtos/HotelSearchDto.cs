using System;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Application.DTOs.HotelDtos
{
    public class HotelSearchDto
    {
        public int? HotelSearchId { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Check-in date is required")]
        public DateTime Checkin { get; set; }

        [Required(ErrorMessage = "Check-out date is required")]
        public DateTime Checkout { get; set; }

        [Required(ErrorMessage = "Guest type is required")]
        public string Guest_Type { get; set; } = string.Empty;

        [Range(1, 10, ErrorMessage = "Guest count must be between 1 and 10")]
        public int Guest_Count { get; set; }

        [Range(1, 5, ErrorMessage = "Room count must be between 1 and 5")]
        public int Room_Count { get; set; }
    }
}