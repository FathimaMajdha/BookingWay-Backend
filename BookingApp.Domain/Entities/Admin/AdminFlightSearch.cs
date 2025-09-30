using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminFlightSearch
    {
        public int Id { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime Depart_Date { get; set; }
        public DateTime? Return_Date { get; set; }
        public string TripType { get; set; }
        public string TravelClass { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
