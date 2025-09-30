using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminBookingService : IAdminBookingService
    {
        private readonly IAdminBookingRepository _repository;

        public AdminBookingService(IAdminBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<AdminBookingDto>>> GetAllAdminBookingsAsync()
        {
            try
            {
                var bookings = await _repository.GetAllAdminBookingsAsync();

                var bookingDtos = bookings.Select(b => new AdminBookingDto
                {
                    UserAuthId = b.UserAuthId,
                    UserName = b.UserName,
                    UserEmail = b.UserEmail,
                    MyBookingId = b.MyBookingId,
                    BookingType = b.BookingType,
                    BookingTypeName = b.BookingTypeName,
                    TotalAmount = b.TotalAmount,
                    PaymentStatus = b.PaymentStatus,
                    BookingDate = b.BookingDate,
                    PassengerName = b.PassengerName,
                    PassengerEmail = b.PassengerEmail,
                    PassengerPhone = b.PassengerPhone,
                    PassengerType = b.PassengerType,
                    HotelName = b.HotelName,
                    GuestName = b.GuestName,
                    GuestEmail = b.GuestEmail,
                    GuestPhone = b.GuestPhone
                });

                return ApiResponse<IEnumerable<AdminBookingDto>>.SuccessResponse(
                    bookingDtos,
                    "Bookings fetched successfully."
                );
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminBookingDto>>.FailResponse(
                    $"Error fetching bookings: {ex.Message}"
                );
            }
        }
    }
}
