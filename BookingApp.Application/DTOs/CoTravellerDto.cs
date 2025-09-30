using System;

namespace BookingApp.Application.DTOs
{
    public class CoTravellerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Relationship { get; set; }
        public string MealPreference { get; set; }
        public string PassportNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? IssuingCountry { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string AirlineName { get; set; }
        public string FrequentFlightNumber { get; set; }
    }
}
