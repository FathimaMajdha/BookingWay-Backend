using BookingApp.Application.Common;
using BookingApp.Application.DTOs.HotelPropertyDto;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly IHotelRoomRepository _repository;

        public HotelRoomService(IHotelRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<int>> AddRoomAsync(HotelRoomDto dto)
        {
            if (dto == null) return ApiResponse<int>.FailResponse("Invalid room data.");
            try
            {
                var result = await _repository.AddRoomAsync(dto);
                return ApiResponse<int>.SuccessResponse(result, "Hotel room added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelRoomDto?>> UpdateRoomAsync(int roomId, HotelRoomDto dto)
        {
            if (dto == null) return ApiResponse<HotelRoomDto?>.FailResponse("Invalid room data.");
            try
            {
                var result = await _repository.UpdateRoomAsync(roomId, dto);
                return ApiResponse<HotelRoomDto?>.SuccessResponse(result, "Hotel room updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelRoomDto?>.FailResponse($"Error updating room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<int>> DeleteRoomAsync(int roomId)
        {
            try
            {
                var result = await _repository.DeleteRoomAsync(roomId);
                return ApiResponse<int>.SuccessResponse(result, "Hotel room deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting room: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<HotelRoom>>> GetAllRoomsAsync()
        {
            try
            {
                var result = await _repository.GetAllRoomsAsync();
                return ApiResponse<IEnumerable<HotelRoom>>.SuccessResponse(result, "Rooms fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<HotelRoom>>.FailResponse($"Error fetching rooms: {ex.Message}");
            }
        }

        public async Task<ApiResponse<HotelRoom?>> GetRoomByIdAsync(int roomId)
        {
            try
            {
                var result = await _repository.GetRoomByIdAsync(roomId);
                if (result == null) return ApiResponse<HotelRoom?>.FailResponse("Room not found.");
                return ApiResponse<HotelRoom?>.SuccessResponse(result, "Room fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<HotelRoom?>.FailResponse($"Error fetching room: {ex.Message}");
            }
        }
    }
}
