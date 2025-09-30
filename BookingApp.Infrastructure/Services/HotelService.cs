using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repo;

        public HotelService(IHotelRepository repo)
        {
            _repo = repo;
        }

        #region Hotel Search CRUD
        public async Task<ApiResponse<int>> AddHotelSearchAsync(HotelSearchDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid hotel search data.");
            try
            {
                var result = await _repo.AddHotelSearchAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel search added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelSearchAsync(HotelSearchDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid hotel search data.");
            try
            {
                var result = await _repo.UpdateHotelSearchAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel search updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelSearchAsync(int hotelSearchId)
        {
            try
            {
                var result = await _repo.DeleteHotelSearchAsync(hotelSearchId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel search deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelSearch>>> GetAllHotelSearchesAsync()
        {
            try
            {
                var result = await _repo.GetAllHotelSearchesAsync();
                return ApiResponse<IEnumerable<HotelSearch>>.SuccessResponse(result, "Hotel searches fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelSearch>>.FailResponse($"Error fetching hotel searches: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelSearch?>> GetHotelSearchByIdAsync(int hotelSearchId)
        {
            try
            {
                var result = await _repo.GetHotelSearchByIdAsync(hotelSearchId);
                if (result == null) return ApiResponse<HotelSearch?>.FailResponse("Hotel search not found.");
                return ApiResponse<HotelSearch?>.SuccessResponse(result, "Hotel search fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelSearch?>.FailResponse($"Error fetching hotel search: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelSearch?>> SearchHotelsAsync(HotelSearchDto dto)
        {
            if (dto == null) return ApiResponse<HotelSearch?>.FailResponse("Invalid search data.");
            try
            {
                var result = await _repo.SearchHotelsAsync(dto);
                return ApiResponse<HotelSearch?>.SuccessResponse(result, "Hotel search completed.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelSearch?>.FailResponse($"Error searching hotels: {ex.Message}");
            }
        }
        #endregion

        #region Hotel CRUD
        public async Task<ApiResponse<int>> AddHotelAsync(HotelDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid hotel data.");
            try
            {
                // Validate required fields
                if (dto.Hotel_Search_Id <= 0)
                    return ApiResponse<int>.FailResponse("Hotel Search Id is required.");

                if (string.IsNullOrWhiteSpace(dto.Hotel_Name))
                    return ApiResponse<int>.FailResponse("Hotel Name is required.");

                var result = await _repo.AddHotelAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelAsync(HotelDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid hotel data.");

            try
            {
                
                if (dto.HotelId == null || dto.HotelId <= 0)
                    return ApiResponse<int>.FailResponse("Valid HotelId is required for update.");

                var result = await _repo.UpdateHotelAsync(dto);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Hotel not found or no changes made.");

                return ApiResponse<int>.SuccessResponse(result, "Hotel updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelAsync(int hotelId)
        {
            try
            {
                if (hotelId <= 0)
                    return ApiResponse<int>.FailResponse("Valid HotelId is required.");

                var result = await _repo.DeleteHotelAsync(hotelId);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Hotel not found.");

                return ApiResponse<int>.SuccessResponse(result, "Hotel deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel: {ex.Message}");
            }
        }

       

        public async Task<ApiResponse<IEnumerable<Hotel>>> GetAllHotelsAsync(int? hotelSearchId = null)
        {
            try
            {
                var result = await _repo.GetAllHotelsAsync(hotelSearchId);
                return ApiResponse<IEnumerable<Hotel>>.SuccessResponse(result, "Hotels fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<Hotel>>.FailResponse($"Error fetching hotels: {ex.Message}");
            }
        }
        public async Task<ApiResponse<Hotel?>> GetHotelByIdAsync(int hotelId)
        {
            try
            {
                if (hotelId <= 0)
                    return ApiResponse<Hotel?>.FailResponse("Valid HotelId is required.");

                var result = await _repo.GetHotelByIdAsync(hotelId);
                if (result == null) return ApiResponse<Hotel?>.FailResponse("Hotel not found.");
                return ApiResponse<Hotel?>.SuccessResponse(result, "Hotel fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<Hotel?>.FailResponse($"Error fetching hotel: {ex.Message}");
            }
        }
        #endregion

        #region Hotel Offers
        public async Task<ApiResponse<int>> AddHotelOfferAsync(HotelOfferDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid offer data.");
            try
            {
                var result = await _repo.AddHotelOfferAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel offer added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel offer: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelOffer>>> GetHotelOffersAsync()
        {
            try
            {
                var result = await _repo.GetHotelOffersAsync();
                return ApiResponse<IEnumerable<HotelOffer>>.SuccessResponse(result, "Hotel offers fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelOffer>>.FailResponse($"Error fetching hotel offers: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelOfferAsync(int offerId, HotelOfferDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid offer data.");

            try
            {
                if (offerId <= 0)
                    return ApiResponse<int>.FailResponse("Valid OfferId is required.");

                var result = await _repo.UpdateHotelOfferAsync(offerId, dto);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Hotel offer not found or no changes made.");

                return ApiResponse<int>.SuccessResponse(result, "Hotel offer updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel offer: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelOfferAsync(int offerId)
        {
            try
            {
                if (offerId <= 0)
                    return ApiResponse<int>.FailResponse("Valid OfferId is required.");

                var result = await _repo.DeleteHotelOfferAsync(offerId);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Hotel offer not found.");

                return ApiResponse<int>.SuccessResponse(result, "Hotel offer deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel offer: {ex.Message}");
            }
        }
        #endregion

        #region Daily Deals
        public async Task<ApiResponse<int>> AddDailyDealAsync(DailyStealDealDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid daily deal data.");
            try
            {
                var result = await _repo.AddDailyDealAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Daily deal added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding daily deal: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<DailyStealDeal>>> GetDailyDealsAsync()
        {
            try
            {
                var result = await _repo.GetDailyDealsAsync();
                return ApiResponse<IEnumerable<DailyStealDeal>>.SuccessResponse(result, "Daily deals fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<DailyStealDeal>>.FailResponse($"Error fetching daily deals: {ex.Message}");
            }
        }

        public async Task<ApiResponse<DailyStealDeal?>> GetDailyDealByIdAsync(int dealId)
        {
            try
            {
                if (dealId <= 0)
                    return ApiResponse<DailyStealDeal?>.FailResponse("Valid DealId is required.");

                var result = await _repo.GetDailyDealByIdAsync(dealId);
                if (result == null) return ApiResponse<DailyStealDeal?>.FailResponse("Daily deal not found.");
                return ApiResponse<DailyStealDeal?>.SuccessResponse(result, "Daily deal fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<DailyStealDeal?>.FailResponse($"Error fetching daily deal: {ex.Message}");
            }
        }
        #endregion

        #region Different Seasons
        public async Task<ApiResponse<int>> AddSeasonAsync(DifferentSeasonDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid season data.");
            try
            {
                var result = await _repo.AddSeasonAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Season added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding season: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<DifferentSeason>>> GetSeasonsAsync()
        {
            try
            {
                var result = await _repo.GetSeasonsAsync();
                return ApiResponse<IEnumerable<DifferentSeason>>.SuccessResponse(result, "Seasons fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<DifferentSeason>>.FailResponse($"Error fetching seasons: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateSeasonAsync(int seasonId, DifferentSeasonDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid season data.");

            try
            {
                if (seasonId <= 0)
                    return ApiResponse<int>.FailResponse("Valid SeasonId is required.");

                var result = await _repo.UpdateSeasonAsync(seasonId, dto);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Season not found or no changes made.");

                return ApiResponse<int>.SuccessResponse(result, "Season updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating season: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteSeasonAsync(int seasonId)
        {
            try
            {
                if (seasonId <= 0)
                    return ApiResponse<int>.FailResponse("Valid SeasonId is required.");

                var result = await _repo.DeleteSeasonAsync(seasonId);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Season not found.");

                return ApiResponse<int>.SuccessResponse(result, "Season deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting season: {ex.Message}");
            }
        }
        #endregion

        #region Popular Destinations
        public async Task<ApiResponse<int>> AddPopularDestinationAsync(PopularDestinationDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid destination data.");
            try
            {
                var result = await _repo.AddPopularDestinationAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Popular destination added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding destination: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<PopularDestination>>> GetPopularDestinationsAsync()
        {
            try
            {
                var result = await _repo.GetPopularDestinationsAsync();
                return ApiResponse<IEnumerable<PopularDestination>>.SuccessResponse(result, "Popular destinations fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<PopularDestination>>.FailResponse($"Error fetching destinations: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeletePopularDestinationAsync(int destinationId)
        {
            try
            {
                if (destinationId <= 0)
                    return ApiResponse<int>.FailResponse("Valid DestinationId is required.");

                var result = await _repo.DeletePopularDestinationAsync(destinationId);

                if (result == 0)
                    return ApiResponse<int>.FailResponse("Popular destination not found.");

                return ApiResponse<int>.SuccessResponse(result, "Popular destination deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting destination: {ex.Message}");
            }
        }
        #endregion

        #region FAQs
        public async Task<ApiResponse<int>> AddHotelFaqAsync(HotelFaqDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid FAQ data.");
            try
            {
                var result = await _repo.AddHotelFaqAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "FAQ added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding FAQ: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelFaq>>> GetHotelFaqsAsync()
        {
            try
            {
                var result = await _repo.GetHotelFaqsAsync();
                return ApiResponse<IEnumerable<HotelFaq>>.SuccessResponse(result, "FAQs fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelFaq>>.FailResponse($"Error fetching FAQs: {ex.Message}");
            }
        }
        #endregion
    }
}