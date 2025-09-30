using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminHotel
    {
        public int HotelId { get; set; }
        public int Hotel_Search_Id { get; set; }
        public string Hotel_Name { get; set; } = null!;
        public string Nearest_Location { get; set; } = null!;
        public string City { get; set; } = null!;
        public decimal Rating { get; set; }
        public string Hotel_Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Reviews { get; set; } = null!;
        public bool FreeCancellation { get; set; }
        public bool BreakfastIncluded { get; set; }
        public string AmenitiesDescription { get; set; } = null!;
        public DateTime Created_At { get; set; }

        public string Hotel_PicturesJson { get; set; } = string.Empty;
        public string Hotel_Pictures { get; set; } = "[]";

        public List<string> GetHotelPicturesList()
        {
            try
            {
                if (!string.IsNullOrEmpty(Hotel_Pictures) && Hotel_Pictures != "[]")
                {
                    return System.Text.Json.JsonSerializer.Deserialize<List<string>>(Hotel_Pictures) ?? new List<string>();
                }
                else if (!string.IsNullOrEmpty(Hotel_PicturesJson))
                {
                    return Hotel_PicturesJson.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                return new List<string>();
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}
