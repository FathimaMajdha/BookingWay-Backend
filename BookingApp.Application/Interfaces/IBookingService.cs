using BookingApp.Application.Common;
using BookingApp.Application.DTOs;

public interface IBookingService
{
    Task<ApiResponse<IEnumerable<MyBookingDto>>> GetMyBookingsAsync(int userAuthId);
    Task<ApiResponse<IEnumerable<MyBookingDto>>> GetMyFlightBookingsAsync(int userAuthId);
    Task<ApiResponse<IEnumerable<MyBookingDto>>> GetMyHotelBookingsAsync(int userAuthId);
    Task<ApiResponse<int>> DeleteBookingAsync(int myBookingId, int userAuthId);
}