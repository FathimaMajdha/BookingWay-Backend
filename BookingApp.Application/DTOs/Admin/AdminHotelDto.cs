namespace BookingApp.Application.DTOs.Admin
{
    public class AdminHotelDto
    {
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

        public List<string> Hotel_Pictures { get; set; } = new List<string>();
    }
}
