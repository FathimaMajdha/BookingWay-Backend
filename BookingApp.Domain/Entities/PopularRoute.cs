using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class PopularRoute
    {
        public int RouteId { get; set; }
        public string RouteFlight_Name { get; set; }
        public string Route_From { get; set; }

        public DateTime Created_At { get; set; }
    }
}
