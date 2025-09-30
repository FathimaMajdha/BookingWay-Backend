using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities.Admin
{
    public class AdminHotelPolicy
    {
        public int PolicyId { get; set; }
        public int HotelId { get; set; }
        public string CheckInTime { get; set; } = null!;
        public string CheckOutTime { get; set; } = null!;
        public string GuestPolicy { get; set; } = null!;
        public string CancellationPolicy { get; set; } = null!;
        public string IdProofPolicy { get; set; } = null!;
        public string AdditionalNotes { get; set; } = null!;
        public DateTime Created_At { get; set; }
    }
}
