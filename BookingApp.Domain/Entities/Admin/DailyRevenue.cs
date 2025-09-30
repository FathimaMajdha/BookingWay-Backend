using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
   public class DailyRevenue
    {
        public DateTime Date { get; set; }    
        public decimal TotalRevenue { get; set; } 
    }
}
