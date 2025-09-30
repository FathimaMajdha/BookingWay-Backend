using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.HotelPropertyDto
{
    public class CreateHotelPolicyDto
    {
        public int HotelId { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string GuestPolicy { get; set; }
        public string CancellationPolicy { get; set; }
        public string IdProofPolicy { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
