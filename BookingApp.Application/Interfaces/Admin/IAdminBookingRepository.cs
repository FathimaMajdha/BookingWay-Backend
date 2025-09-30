using BookingApp.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IAdminBookingRepository
    {
        Task<IEnumerable<AdminBooking>> GetAllAdminBookingsAsync();
    }
}
