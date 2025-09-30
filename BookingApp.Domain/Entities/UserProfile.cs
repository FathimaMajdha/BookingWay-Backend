using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public int UserAuthId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public string UserImage { get; set; } = "";
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; } = "";
        public string MaritalStatus { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string MobileNumber { get; set; } = "";
      
        public string PassportNumber { get; set; } = "";
        public DateTime? ExpiryDate { get; set; }
        public string IssuingCountry { get; set; } = "";
        public string PancardNumber { get; set; } = "";
        public string AirlineName { get; set; } = "";
        public string FrequentFlightNumber { get; set; } = "";
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}

