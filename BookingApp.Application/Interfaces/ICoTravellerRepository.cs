using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface ICoTravellerRepository
    {



        Task<int> AddCoTravellerAsync(int userAuthId, CoTravellerDto traveller);



        Task<int> UpdateCoTravellerAsync(int coTravellerId, CoTravellerDto traveller);



        Task<int> DeleteCoTravellerAsync(int coTravellerId);


        Task<IEnumerable<CoTraveller>> GetAllCoTravellersAsync();


        Task<CoTraveller?> GetCoTravellersByIdAsync(int coTravellerId);


    }
}
