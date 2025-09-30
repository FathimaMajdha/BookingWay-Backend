using System;

namespace BookingApp.Domain.Entities.Admin
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime? ValidDate { get; set; }
    }

}
