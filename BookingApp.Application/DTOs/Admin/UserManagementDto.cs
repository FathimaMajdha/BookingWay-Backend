using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class UserManagementDto
    {
        public int UserAuthId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public int TotalBookings { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<UserBookingDetailDto> Bookings { get; set; } = new();
    }

}
