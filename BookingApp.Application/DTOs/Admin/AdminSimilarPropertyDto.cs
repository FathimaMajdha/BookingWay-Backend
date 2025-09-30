using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class AdminSimilarPropertyDto
    {
     
        public int HotelId { get; set; }
        public string SimilarHotel_Name { get; set; }
        public string Location { get; set; }
        public string Reviews { get; set; }
        public decimal Rating { get; set; }
        public decimal Price_Per_Night { get; set; }
        public string ImageUrl { get; set; }
    }
}
