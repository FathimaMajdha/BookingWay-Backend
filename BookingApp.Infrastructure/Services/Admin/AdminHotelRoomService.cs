using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using BookingApp.Domain.Entities.Admin;
using BookingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class AdminHotelRoomService : IAdminHotelRoomService
    {
        private readonly IAdminHotelRoomRepository _repo;

        public AdminHotelRoomService(IAdminHotelRoomRepository repo)
        {
            _repo = repo;
        }

        public async Task<ApiResponse<int>> AddHotelRoomAsync(AdminHotelRoomDto dto)
        {
            try
            {
              
                if (dto == null)
                    return ApiResponse<int>.FailResponse("Hotel room data cannot be null.");

                if (dto.HotelId <= 0)
                    return ApiResponse<int>.FailResponse("Valid Hotel ID is required.");

                if (string.IsNullOrWhiteSpace(dto.Room_Type))
                    return ApiResponse<int>.FailResponse("Room type is required.");

                if (string.IsNullOrWhiteSpace(dto.Room_Image))
                    return ApiResponse<int>.FailResponse("Room image is required.");

                if (dto.Price <= 0)
                    return ApiResponse<int>.FailResponse("Valid room price is required.");

                if (dto.Available_Rooms <= 0)
                    return ApiResponse<int>.FailResponse("Available rooms count must be greater than 0.");

                if (dto.MaximumGuest_Count <= 0)
                    return ApiResponse<int>.FailResponse("Maximum guest count must be greater than 0.");

                var result = await _repo.AddHotelRoomAsync(dto);

                if (result > 0)
                    return ApiResponse<int>.SuccessResponse(result, "Hotel room added successfully.");
                else
                    return ApiResponse<int>.FailResponse("Failed to add hotel room. No ID returned.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding hotel room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> UpdateHotelRoomAsync(int roomId, AdminHotelRoomDto dto)
        {
            try
            {
                if (roomId <= 0)
                    return ApiResponse<int>.FailResponse("Valid Room ID is required.");

                if (dto == null)
                    return ApiResponse<int>.FailResponse("Hotel room data cannot be null.");

                if (dto.HotelId <= 0)
                    return ApiResponse<int>.FailResponse("Valid Hotel ID is required.");

                if (string.IsNullOrWhiteSpace(dto.Room_Type))
                    return ApiResponse<int>.FailResponse("Room type is required.");

                if (string.IsNullOrWhiteSpace(dto.Room_Image))
                    return ApiResponse<int>.FailResponse("Room image is required.");

                if (dto.Price <= 0)
                    return ApiResponse<int>.FailResponse("Valid room price is required.");

                if (dto.Available_Rooms <= 0)
                    return ApiResponse<int>.FailResponse("Available rooms count must be greater than 0.");

                if (dto.MaximumGuest_Count <= 0)
                    return ApiResponse<int>.FailResponse("Maximum guest count must be greater than 0.");

              
                var existingRoom = await _repo.GetHotelRoomByIdAsync(roomId);
                if (existingRoom == null)
                    return ApiResponse<int>.FailResponse($"Hotel room with ID {roomId} not found.");

                var result = await _repo.UpdateHotelRoomAsync(roomId, dto);

                if (result > 0)
                    return ApiResponse<int>.SuccessResponse(result, "Hotel room updated successfully.");
                else
                    return ApiResponse<int>.FailResponse("No rows were updated. Room may not exist or data may be unchanged.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating hotel room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteHotelRoomAsync(int roomId)
        {
            try
            {
                if (roomId <= 0)
                    return ApiResponse<int>.FailResponse("Valid Room ID is required.");

                
                var existingRoom = await _repo.GetHotelRoomByIdAsync(roomId);
                if (existingRoom == null)
                    return ApiResponse<int>.FailResponse($"Hotel room with ID {roomId} not found.");

                var result = await _repo.DeleteHotelRoomAsync(roomId);

                if (result > 0)
                    return ApiResponse<int>.SuccessResponse(result, "Hotel room deleted successfully.");
                else
                    return ApiResponse<int>.FailResponse("No rows were deleted. Room may not exist.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting hotel room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<AdminHotelRoom>>> GetAllHotelRoomAsync(int? hotelId = null)
        {
            try
            {
               
                if (hotelId.HasValue && hotelId.Value <= 0)
                    return ApiResponse<IEnumerable<AdminHotelRoom>>.FailResponse("Valid Hotel ID is required when filtering by hotel.");

                var result = await _repo.GetAllHotelRoomAsync(hotelId);

                var roomsList = result?.ToList() ?? new List<AdminHotelRoom>();

                string message = hotelId.HasValue
                    ? $"Hotel rooms for Hotel ID {hotelId.Value} fetched successfully. Found {roomsList.Count} room(s)."
                    : $"All hotel rooms fetched successfully. Found {roomsList.Count} room(s).";

                return ApiResponse<IEnumerable<AdminHotelRoom>>.SuccessResponse(roomsList, message);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AdminHotelRoom>>.FailResponse($"Error fetching hotel rooms: {ex.Message}");
            }
        }

        public async Task<ApiResponse<AdminHotelRoom?>> GetHotelRoomByIdAsync(int roomId)
        {
            try
            {
                if (roomId <= 0)
                    return ApiResponse<AdminHotelRoom?>.FailResponse("Valid Room ID is required.");

                var result = await _repo.GetHotelRoomByIdAsync(roomId);

                if (result == null)
                    return ApiResponse<AdminHotelRoom?>.FailResponse($"Hotel room with ID {roomId} not found.");

                return ApiResponse<AdminHotelRoom?>.SuccessResponse(result, "Hotel room fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<AdminHotelRoom?>.FailResponse($"Error fetching hotel room: {ex.Message}");
            }
        }
    }
}