using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminHotelDining
    {
        public int? DiningId { get; set; }
        public int HotelId { get; set; }

        public string DiningExperience { get; set; } = null!;
        public string? MealOptions { get; set; }
        public string RestaurantHours { get; set; } = null!;
        public string RestaurantDescription { get; set; } = null!;
        public string? SpecialFeatures { get; set; }
        public DateTime Created_At { get; set; }
    }
}
