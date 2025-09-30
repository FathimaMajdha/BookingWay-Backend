using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.HotelDtos
{
    public class DifferentSeasonDto
    {
        public string Season_Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Location_Image { get; set; }
        public string Location_Name { get; set; }
    }
}
