using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class PopularDestination
    {
        public int DestinationId { get; set; }
        public string Location_Image { get; set; }
        public string Location_Name { get; set; }
        public string Location_Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}
