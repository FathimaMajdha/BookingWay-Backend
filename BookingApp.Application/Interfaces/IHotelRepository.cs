using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelRepository
    {
        #region Hotel CRUD Operations
        Task<int> AddHotelAsync(HotelDto dto);
        Task<int> UpdateHotelAsync(HotelDto dto);
        Task<int> DeleteHotelAsync(int hotelId);
        Task<IEnumerable<Hotel>> GetAllHotelsAsync(int? hotelSearchId = null);
        Task<Hotel?> GetHotelByIdAsync(int hotelId);
        #endregion

        #region Hotel Search Operations
        Task<int> AddHotelSearchAsync(HotelSearchDto dto);
        Task<int> UpdateHotelSearchAsync(HotelSearchDto dto);
        Task<int> DeleteHotelSearchAsync(int hotelSearchId);
        Task<IEnumerable<HotelSearch>> GetAllHotelSearchesAsync();
        Task<HotelSearch?> GetHotelSearchByIdAsync(int hotelSearchId);
        Task<HotelSearch?> SearchHotelsAsync(HotelSearchDto dto);
        #endregion

        #region Hotel Offers Operations
        Task<int> AddHotelOfferAsync(HotelOfferDto dto);
        Task<IEnumerable<HotelOffer>> GetHotelOffersAsync();
        Task<int> UpdateHotelOfferAsync(int offerId, HotelOfferDto dto);
        Task<int> DeleteHotelOfferAsync(int offerId);
        #endregion

        #region Daily Steal Deals Operations
        Task<int> AddDailyDealAsync(DailyStealDealDto dto);
        Task<IEnumerable<DailyStealDeal>> GetDailyDealsAsync();
        Task<DailyStealDeal?> GetDailyDealByIdAsync(int dealId);
        #endregion

        #region Different Seasons Operations
        Task<int> AddSeasonAsync(DifferentSeasonDto dto);
        Task<IEnumerable<DifferentSeason>> GetSeasonsAsync();
        Task<int> UpdateSeasonAsync(int seasonId, DifferentSeasonDto dto);
        Task<int> DeleteSeasonAsync(int seasonId);
        #endregion

        #region Popular Destinations Operations
        Task<int> AddPopularDestinationAsync(PopularDestinationDto dto);
        Task<IEnumerable<PopularDestination>> GetPopularDestinationsAsync();
        Task<int> DeletePopularDestinationAsync(int destinationId);
        #endregion

        #region Hotel Booking FAQs Operations
        Task<int> AddHotelFaqAsync(HotelFaqDto dto);
        Task<IEnumerable<HotelFaq>> GetHotelFaqsAsync();
        #endregion
    }
}