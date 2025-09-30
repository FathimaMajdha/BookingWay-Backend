using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces
{
    public interface ICoTravellerService
    {
        Task<ApiResponse<int>> AddCoTravellerAsync(int userAuthId, CoTravellerDto traveller);
        Task<ApiResponse<int>> UpdateCoTravellerAsync(int coTravellerId, CoTravellerDto traveller);
        Task<ApiResponse<int>> DeleteCoTravellerAsync(int coTravellerId);
        Task<ApiResponse<IEnumerable<CoTraveller>>> GetAllCoTravellersAsync();
        Task<ApiResponse<CoTraveller?>> GetCoTravellersByIdAsync(int coTravellerId);
           
    }


}
