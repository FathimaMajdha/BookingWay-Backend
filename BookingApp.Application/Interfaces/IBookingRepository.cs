using BookingApp.Application.DTOs;

public interface IBookingRepository
{
    Task<IEnumerable<MyBookingDto>> GetMyBookingsAsync(int userAuthId);
    Task<IEnumerable<MyBookingDto>> GetMyFlightBookingsAsync(int userAuthId);
    Task<IEnumerable<MyBookingDto>> GetMyHotelBookingsAsync(int userAuthId);
    Task<int> DeleteBookingAsync(int myBookingId, int userAuthId);
}