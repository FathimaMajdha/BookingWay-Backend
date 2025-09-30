using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class DailyStealDeal
    {
        public int DealId { get; set; }
        public decimal Rating { get; set; }
        public string Image { get; set; }
        public string Hotel_Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public decimal Price_Per_Night { get; set; }
        public DateTime Created_At { get; set; }
    }
}
