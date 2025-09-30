using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<MyBookingDto>> GetMyBookingsAsync(int userAuthId);
    }
}
