using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class DifferentSeason
    {
        public int SeasonId { get; set; }
        public string Season_Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Location_Image { get; set; }
        public string Location_Name { get; set; }
        public DateTime Created_At { get; set; }
    }

}
