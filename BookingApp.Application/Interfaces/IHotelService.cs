// IHotelService.cs
using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelService
    {
        #region Hotel Search CRUD
        Task<ApiResponse<int>> AddHotelSearchAsync(HotelSearchDto dto);
        Task<ApiResponse<int>> UpdateHotelSearchAsync(HotelSearchDto dto);
        Task<ApiResponse<int>> DeleteHotelSearchAsync(int hotelSearchId);
        Task<ApiResponse<IEnumerable<HotelSearch>>> GetAllHotelSearchesAsync();
        Task<ApiResponse<HotelSearch?>> GetHotelSearchByIdAsync(int hotelSearchId);
        Task<ApiResponse<HotelSearch?>> SearchHotelsAsync(HotelSearchDto dto);
        #endregion

        #region Hotel CRUD
        Task<ApiResponse<int>> AddHotelAsync(HotelDto dto);
        Task<ApiResponse<int>> UpdateHotelAsync(HotelDto dto);
        Task<ApiResponse<int>> DeleteHotelAsync(int hotelId);

     
        Task<ApiResponse<IEnumerable<Hotel>>> GetAllHotelsAsync(int? hotelSearchId = null);

        Task<ApiResponse<Hotel?>> GetHotelByIdAsync(int hotelId);
        #endregion

        #region Hotel Offers
        Task<ApiResponse<int>> AddHotelOfferAsync(HotelOfferDto dto);
        Task<ApiResponse<IEnumerable<HotelOffer>>> GetHotelOffersAsync();
        Task<ApiResponse<int>> UpdateHotelOfferAsync(int offerId, HotelOfferDto dto);
        Task<ApiResponse<int>> DeleteHotelOfferAsync(int offerId);
        #endregion

        #region Daily Deals
        Task<ApiResponse<int>> AddDailyDealAsync(DailyStealDealDto dto);
        Task<ApiResponse<IEnumerable<DailyStealDeal>>> GetDailyDealsAsync();
        Task<ApiResponse<DailyStealDeal?>> GetDailyDealByIdAsync(int dealId);
        #endregion

        #region Different Seasons
        Task<ApiResponse<int>> AddSeasonAsync(DifferentSeasonDto dto);
        Task<ApiResponse<IEnumerable<DifferentSeason>>> GetSeasonsAsync();
        Task<ApiResponse<int>> UpdateSeasonAsync(int seasonId, DifferentSeasonDto dto);
        Task<ApiResponse<int>> DeleteSeasonAsync(int seasonId);
        #endregion

        #region Popular Destinations
        Task<ApiResponse<int>> AddPopularDestinationAsync(PopularDestinationDto dto);
        Task<ApiResponse<IEnumerable<PopularDestination>>> GetPopularDestinationsAsync();
        Task<ApiResponse<int>> DeletePopularDestinationAsync(int destinationId);
        #endregion

        #region FAQs
        Task<ApiResponse<int>> AddHotelFaqAsync(HotelFaqDto dto);
        Task<ApiResponse<IEnumerable<HotelFaq>>> GetHotelFaqsAsync();
        #endregion
    }
}