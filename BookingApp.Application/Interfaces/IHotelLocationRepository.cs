using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface IHotelLocationRepository
    {

        Task<int> AddLocationAsync(CreateHotelLocationDto dto);


        Task<int> UpdateLocationAsync(int locationId, CreateHotelLocationDto dto);

        Task<int> DeleteLocationAsync(int locationId);

        Task<IEnumerable<HotelLocation>> GetAllLocationAsync();

        Task<HotelLocation> GetLocationByIdAsync(int locationId);
       
    }
}
