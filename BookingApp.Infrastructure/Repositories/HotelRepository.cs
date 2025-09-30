using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System.Data;
using System.Text.Json;

namespace BookingApp.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IDbConnection _connection;
        private readonly JsonSerializerOptions _jsonOptions;

        public HotelRepository(IDbConnection connection)
        {
            _connection = connection;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null,
                PropertyNameCaseInsensitive = true
            };
        }

        #region Hotel CRUD Operations

        public async Task<int> AddHotelAsync(HotelDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.Hotel_Search_Id,
                dto.Hotel_Name,
                dto.Nearest_Location,
                dto.City,
                dto.Rating,
                dto.Hotel_Description,
                dto.Price,
                dto.Reviews,
                dto.FreeCancellation,
                dto.BreakfastIncluded,
                Hotel_Pictures = dto.Hotel_Pictures ?? new List<string>(),
                Hotel_PicturesArray = dto.Hotel_Pictures ?? new List<string>() 
            }, _jsonOptions);

            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_Hotel",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );

            return result?.InsertedHotelId ?? 0;
        }

        public async Task<int> UpdateHotelAsync(HotelDto dto)
        {
            if (dto.HotelId == null || dto.HotelId == 0)
                throw new ArgumentException("HotelId is required for update");

            var json = JsonSerializer.Serialize(new
            {
                HotelId = dto.HotelId,
                dto.Hotel_Search_Id,
                dto.Hotel_Name,
                dto.Nearest_Location,
                dto.City,
                dto.Rating,
                dto.Hotel_Description,
                dto.Price,
                dto.Reviews,
                dto.FreeCancellation,
                dto.BreakfastIncluded,
                Hotel_Pictures = dto.Hotel_Pictures ?? new List<string>(),
                Hotel_PicturesArray = dto.Hotel_Pictures ?? new List<string>() 
            }, _jsonOptions);

            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_Hotel",
                new { Flag = 2, JSON = json, HotelId = dto.HotelId },
                commandType: CommandType.StoredProcedure
            );

            return result?.RowsUpdated ?? 0;
        }

        public async Task<int> DeleteHotelAsync(int hotelId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_Hotel",
                new { Flag = 3, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );

            return result?.Deleted ?? 0;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync(int? hotelSearchId = null)
        {
            var results = await _connection.QueryAsync<dynamic>(
                "sp_Hotel",
                new { Flag = 4, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );

            var hotels = new List<Hotel>();

            foreach (var result in results)
            {
                var hotel = MapHotelFromDynamic(result);
                hotels.Add(hotel);
            }

            return hotels;
        }

        public async Task<Hotel?> GetHotelByIdAsync(int hotelId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<dynamic>(
                "sp_Hotel",
                new { Flag = 5, HotelId = hotelId },
                commandType: CommandType.StoredProcedure
            );

            if (result == null) return null;

            return MapHotelFromDynamic(result);
        }

        private Hotel MapHotelFromDynamic(dynamic result)
        {
            var hotel = new Hotel
            {
                HotelId = result.HotelId,
                Hotel_Search_Id = result.Hotel_Search_Id,
                Hotel_Name = result.Hotel_Name,
                Nearest_Location = result.Nearest_Location,
                City = result.City,
                Rating = result.Rating,
                Hotel_Description = result.Hotel_Description,
                Price = result.Price,
                Reviews = result.Reviews,
                FreeCancellation = result.FreeCancellation,
                BreakfastIncluded = result.BreakfastIncluded,
                Hotel_Pictures = ProcessHotelPictures(result.Hotel_Pictures),
                Created_At = result.Created_At
            };

          
            if (result.Hotel_PicturesArray != null)
            {
                try
                {
                    var picturesArray = JsonSerializer.Deserialize<List<string>>(
                        result.Hotel_PicturesArray.ToString(), _jsonOptions);

                    
                    if (picturesArray != null && picturesArray.Any())
                    {
                        hotel.Hotel_Pictures = picturesArray;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing Hotel_PicturesArray: {ex.Message}");
                }
            }

            return hotel;
        }

        private List<string> ProcessHotelPictures(object hotelPictures)
        {
            if (hotelPictures == null) return new List<string>();

            try
            {

                if (hotelPictures is string jsonString)
                {
                    if (string.IsNullOrEmpty(jsonString) || jsonString.Trim() == "[]" || jsonString.Trim() == "-")
                        return new List<string>();

                   
                    if (jsonString.Trim().StartsWith('['))
                    {
                        var pictures = JsonSerializer.Deserialize<List<string>>(jsonString, _jsonOptions);
                        return pictures ?? new List<string>();
                    }

                    
                    if (jsonString.Contains(','))
                    {
                        return jsonString.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(url => url.Trim())
                                       .Where(url => !string.IsNullOrEmpty(url))
                                       .ToList();
                    }

                    
                    if (!string.IsNullOrEmpty(jsonString.Trim()) && jsonString.Trim() != "-")
                    {
                        return new List<string> { jsonString.Trim() };
                    }
                }

                
                if (hotelPictures is List<string> picturesList)
                {
                    return picturesList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing hotel pictures: {ex.Message}");
            }

            return new List<string>();
        }

        #endregion

        #region Hotel Search

        public async Task<int> AddHotelSearchAsync(HotelSearchDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.Location,
                dto.Checkin,
                dto.Checkout,
                dto.Guest_Type,
                dto.Guest_Count,
                dto.Room_Count
            }, _jsonOptions);

            await _connection.ExecuteAsync(
                "sp_Hotel_Search",
                new { Flag = 1, Json = json },
                commandType: CommandType.StoredProcedure
            );

            
            var latestId = await _connection.QueryFirstOrDefaultAsync<int?>(
                "SELECT MAX(HotelSearchId) FROM Hotel_Search"
            );

            return latestId ?? 0;
        }

        public async Task<int> UpdateHotelSearchAsync(HotelSearchDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.HotelSearchId,
                dto.Location,
                dto.Checkin,
                dto.Checkout,
                dto.Guest_Type,
                dto.Guest_Count,
                dto.Room_Count
            }, _jsonOptions);

            return await _connection.ExecuteAsync(
                "sp_Hotel_Search",
                new { Flag = 2, Json = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteHotelSearchAsync(int hotelSearchId)
        {
            return await _connection.ExecuteAsync(
                "sp_Hotel_Search",
                new { Flag = 3, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelSearch>> GetAllHotelSearchesAsync()
        {
            return await _connection.QueryAsync<HotelSearch>(
                "sp_Hotel_Search",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelSearch?> GetHotelSearchByIdAsync(int hotelSearchId)
        {
            return await _connection.QueryFirstOrDefaultAsync<HotelSearch>(
                "sp_Hotel_Search",
                new { Flag = 5, HotelSearchId = hotelSearchId },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<HotelSearch?> SearchHotelsAsync(HotelSearchDto dto)
        {
            var json = JsonSerializer.Serialize(dto, _jsonOptions);

            return await _connection.QueryFirstOrDefaultAsync<HotelSearch>(
                "sp_Hotel_Search",
                new { Flag = 6, Json = json },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion

        #region Hotel Offers

        public async Task<int> AddHotelOfferAsync(HotelOfferDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                dto.Hotel_Name,
                dto.Hotel_Image,
                dto.HotelOffer_Description,
                dto.DiscountPercentage,
                dto.Valid_Date
            }, _jsonOptions);

            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelOffer",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelOffer>> GetHotelOffersAsync()
        {
            return await _connection.QueryAsync<HotelOffer>(
                "sp_HotelOffer",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateHotelOfferAsync(int offerId, HotelOfferDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                HotelOfferId = offerId,
                dto.Hotel_Name,
                dto.Hotel_Image,
                dto.HotelOffer_Description,
                dto.DiscountPercentage,
                dto.Valid_Date
            }, _jsonOptions);

            var updatedId = await _connection.ExecuteScalarAsync<int>(
                "sp_HotelOffer",
                new { Flag = 2, JSON = json },
                commandType: CommandType.StoredProcedure
            );

            return updatedId;
        }

        public async Task<int> DeleteHotelOfferAsync(int offerId)
        {
            return await _connection.ExecuteAsync(
                "sp_HotelOffer",
                new { Flag = 3, HotelOfferId = offerId },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion

        #region Daily Steal Deals

        public async Task<int> AddDailyDealAsync(DailyStealDealDto dto)
        {
            var json = JsonSerializer.Serialize(dto, _jsonOptions);

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Daily_Steal_Deals",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<DailyStealDeal>> GetDailyDealsAsync()
        {
            return await _connection.QueryAsync<DailyStealDeal>(
                "sp_Daily_Steal_Deals",
                new { Flag = 2 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<DailyStealDeal?> GetDailyDealByIdAsync(int dealId)
        {
            return await _connection.QueryFirstOrDefaultAsync<DailyStealDeal>(
                "sp_Daily_Steal_Deals",
                new { Flag = 3, DealId = dealId },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion

        #region Different Seasons

        public async Task<int> AddSeasonAsync(DifferentSeasonDto dto)
        {
            var json = JsonSerializer.Serialize(dto, _jsonOptions);

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Different_Seasons",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<DifferentSeason>> GetSeasonsAsync()
        {
            return await _connection.QueryAsync<DifferentSeason>(
                "sp_Different_Seasons",
                new { Flag = 4 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> UpdateSeasonAsync(int seasonId, DifferentSeasonDto dto)
        {
            var json = JsonSerializer.Serialize(new
            {
                SeasonId = seasonId,
                dto.Season_Name,
                dto.Description,
                dto.Start_Date,
                dto.End_Date,
                dto.Location_Image,
                dto.Location_Name
            }, _jsonOptions);

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Different_Seasons",
                new { Flag = 2, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeleteSeasonAsync(int seasonId)
        {
            return await _connection.ExecuteAsync(
                "sp_Different_Seasons",
                new { Flag = 3, SeasonId = seasonId },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion

        #region Popular Destinations

        public async Task<int> AddPopularDestinationAsync(PopularDestinationDto dto)
        {
            var json = JsonSerializer.Serialize(dto, _jsonOptions);

            return await _connection.ExecuteScalarAsync<int>(
                "sp_Popular_Destinations",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<PopularDestination>> GetPopularDestinationsAsync()
        {
            return await _connection.QueryAsync<PopularDestination>(
                "sp_Popular_Destinations",
                new { Flag = 3 },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<int> DeletePopularDestinationAsync(int destinationId)
        {
            return await _connection.ExecuteAsync(
                "sp_Popular_Destinations",
                new { Flag = 2, DestinationId = destinationId },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion

        #region Hotel Booking FAQs

        public async Task<int> AddHotelFaqAsync(HotelFaqDto dto)
        {
            var json = JsonSerializer.Serialize(dto, _jsonOptions);

            return await _connection.ExecuteScalarAsync<int>(
                "sp_HotelBooking_Faqs",
                new { Flag = 1, JSON = json },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<IEnumerable<HotelFaq>> GetHotelFaqsAsync()
        {
            return await _connection.QueryAsync<HotelFaq>(
                "sp_HotelBooking_Faqs",
                new { Flag = 2 },
                commandType: CommandType.StoredProcedure
            );
        }

        #endregion
    }
}