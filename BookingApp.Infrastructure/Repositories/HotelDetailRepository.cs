using BookingApp.Application.DTOs.HotelDtos;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Repositories
{
    public class HotelDetailRepository : IHotelDetailRepository
    {
        private readonly IDbConnection _connection;

        public HotelDetailRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<HotelDetailDto>> GetHotelDetailsAsync()
        {
            var details = await _connection.QueryAsync<HotelDetailDto, HotelDto, HotelRoomDto, AmenityDto, HotelDetailDto>(
                "sp_Hotel_Detail",
                (hd, hotel, room, amenity) =>
                {
                    hd.Hotel = hotel;
                    hd.Room = room;
                    hd.Amenity = amenity;
                    return hd;
                },
                new { Flag = 1 },
                splitOn: "HotelId,RoomId,AmenityId",
                commandType: CommandType.StoredProcedure
            );

            return details;
        }

        public async Task<HotelDetailDto> GetHotelDetailByIdAsync(int hotelDetailId)
        {
            var detail = await _connection.QueryAsync<HotelDetailDto, HotelDto, HotelRoomDto, AmenityDto, HotelDetailDto>(
                "sp_Hotel_Detail",
                (hd, hotel, room, amenity) =>
                {
                    hd.Hotel = hotel;
                    hd.Room = room;
                    hd.Amenity = amenity;
                    return hd;
                },
                new { Flag = 2, HotelDetailId = hotelDetailId },
                splitOn: "HotelId,RoomId,AmenityId",
                commandType: CommandType.StoredProcedure
            );

            return detail.FirstOrDefault();
        }

        public async Task<int> DeleteHotelDetailAsync(int hotelDetailId)
        {
            return await _connection.ExecuteAsync(
                "sp_Hotel_Detail",
                new { Flag = 3, HotelDetailId = hotelDetailId },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
