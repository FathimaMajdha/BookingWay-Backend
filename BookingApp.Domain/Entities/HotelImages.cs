namespace BookingApp.Domain.Entities
{
    public class HotelImages
    {
        public int ImageId { get; set; }
        public int HotelId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public Hotel? Hotel { get; set; }
    }
}