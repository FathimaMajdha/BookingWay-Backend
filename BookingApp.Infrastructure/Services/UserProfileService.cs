using BookingApp.Application.Common;
using BookingApp.Application.DTOs;
using BookingApp.Application.Interfaces;
using BookingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ICloudStorageService _cloudStorage;

        public UserProfileService(IUserProfileRepository userProfileRepository, ICloudStorageService cloudStorage)
        {
            _userProfileRepository = userProfileRepository;
            _cloudStorage = cloudStorage;
        }

        public async Task<ApiResponse<int>> AddUserAsync(UserProfileDto user, int userAuthId)
        {
            try
            {
                if (user.UserImageFile != null)
                {
                    var uploadResponse = await _cloudStorage.UploadImageAsync(user.UserImageFile, "userprofiles");

                    if (!uploadResponse.Success)
                        return ApiResponse<int>.FailResponse(uploadResponse.Message);

                    user.UserImage = uploadResponse.Data;
                }

                var result = await _userProfileRepository.AddUserAsync(userAuthId, user);
                return ApiResponse<int>.SuccessResponse(result, "User profile added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error adding user profile: {ex.Message}");
            }
        }


        public async Task<ApiResponse<int>> UpdateUserAsync(int userId, UserProfileDto user)
        {
            try
            {
                if (user.UserImageFile != null)
                {
                    var uploadResponse = await _cloudStorage.UploadImageAsync(user.UserImageFile, "userprofiles");

                    if (!uploadResponse.Success)
                        return ApiResponse<int>.FailResponse(uploadResponse.Message);

                    user.UserImage = uploadResponse.Data;
                }

                var result = await _userProfileRepository.UpdateUserAsync(userId, user);
                return ApiResponse<int>.SuccessResponse(result, "User profile updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error updating user profile: {ex.Message}");
            }
        }


        public async Task<ApiResponse<int>> DeleteUserAsync(int userAuthId)
        {
            try
            {
                var result = await _userProfileRepository.DeleteUserAsync(userAuthId);
                return ApiResponse<int>.SuccessResponse(result, "User profile deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<int>.FailResponse($"Error deleting user profile: {ex.Message}");
            }
        }

        public async Task<ApiResponse<IEnumerable<UserProfile>>> GetAllAsync()
        {
            try
            {
                var result = await _userProfileRepository.GetAllAsync();
                return ApiResponse<IEnumerable<UserProfile>>.SuccessResponse(result, "User profiles fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<UserProfile>>.FailResponse($"Error fetching user profiles: {ex.Message}");
            }
        }

        public async Task<ApiResponse<UserProfile?>> GetByAuthIdAsync(int userAuthId)
        {
            try
            {
                var result = await _userProfileRepository.GetByAuthIdAsync(userAuthId);
                if (result == null) return ApiResponse<UserProfile?>.FailResponse("User profile not found.");
                return ApiResponse<UserProfile?>.SuccessResponse(result, "User profile fetched successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<UserProfile?>.FailResponse($"Error fetching user profile: {ex.Message}");
            }
        }
    }
}
