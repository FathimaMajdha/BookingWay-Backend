using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.HotelPropertyDto
{
    public class HotelDiningDto
    {
        public int HotelId { get; set; }

        public string DiningExperience { get; set; }
        public string MealOptions { get; set; }
        public string RestaurantHours { get; set; }
        public string RestaurantDescription { get; set; }
        public string SpecialFeatures { get; set; }
    }
}
