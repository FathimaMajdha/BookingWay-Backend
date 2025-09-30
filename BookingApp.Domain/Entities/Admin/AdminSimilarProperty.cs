using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminSimilarProperty
    {
        public int SimilarId { get; set; }
        public int HotelId { get; set; }
        public string SimilarHotel_Name { get; set; }
        public string Location { get; set; }
        public string Reviews { get; set; }
        public decimal Rating { get; set; }
        public decimal Price_Per_Night { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
