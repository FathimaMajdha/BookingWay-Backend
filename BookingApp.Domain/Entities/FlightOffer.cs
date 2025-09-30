using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class FlightOffer
    {
        public int FlightOfferId { get; set; }
        public string Flight_Name { get; set; }
        public string Flight_Image { get; set; }
        public string FlightOffer_Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime Valid_Date { get; set; }

        public DateTime Created_At { get; set; }
    }
}
