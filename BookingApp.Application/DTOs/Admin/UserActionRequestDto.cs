using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.DTOs.Admin
{
    public class UserActionRequestDto
    {
        public int UserAuthId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }

}
