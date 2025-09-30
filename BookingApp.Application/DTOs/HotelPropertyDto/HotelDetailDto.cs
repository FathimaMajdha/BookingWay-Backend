using BookingApp.Application.DTOs.HotelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.HotelPropertyDto
{
    public class HotelDetailDto
    {
        public int HotelDetailId { get; set; }

        public HotelDto Hotel { get; set; }

        public HotelRoomDto Room { get; set; }

        public AmenityDto Amenity { get; set; }


        public string Description { get; set; }

        public DateTime Created_At { get; set; }
    }
}
