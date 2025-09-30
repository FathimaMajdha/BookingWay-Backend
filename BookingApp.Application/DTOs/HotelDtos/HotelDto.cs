using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingApp.Application.DTOs.HotelDtos
{
    public class HotelDto
    {
        public int? HotelId { get; set; }

       
        public int Hotel_Search_Id { get; set; }

       
        public string Hotel_Name { get; set; } = string.Empty;

       
        public string Nearest_Location { get; set; } = string.Empty;

      
        public string City { get; set; } = string.Empty;

       
        public decimal Rating { get; set; }

        public string Hotel_Description { get; set; } = string.Empty;

       
        public decimal Price { get; set; }

        public string Reviews { get; set; } = string.Empty;

        public bool FreeCancellation { get; set; }

        public bool BreakfastIncluded { get; set; }

        public List<string> Hotel_Pictures { get; set; } = new List<string>();
    }
}