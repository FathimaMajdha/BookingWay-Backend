using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Entities
{
    public class HotelDetail
    {
        public int HotelDetailId { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}
