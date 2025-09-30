using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class HotelOffer
    {
        public int HotelOfferId { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Image { get; set; }
        public string HotelOffer_Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime Valid_Date { get; set; }
        public DateTime Created_At { get; set; }
    }
}
