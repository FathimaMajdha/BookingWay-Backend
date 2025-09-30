using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using System;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Services.Admin
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserManagementRepository _repository;

        public UserManagementService(IUserManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<PaginatedResponseDto<UserManagementDto>>> GetUsersAsync(PaginationRequestDto request)
        {
            try
            {
                
                if (request.PageNumber < 1)
                    request.PageNumber = 1;

                if (request.PageSize < 1 || request.PageSize > 100)
                    request.PageSize = 10;

                var result = await _repository.GetUsersAsync(request);
                return ApiResponse<PaginatedResponseDto<UserManagementDto>>.SuccessResponse(result, "Users retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<PaginatedResponseDto<UserManagementDto>>.FailResponse($"Error retrieving users: {ex.Message}");
            }
        }

        public async Task<ApiResponse<UserActionResponseDto>> BlockUserAsync(int userAuthId)
        {
            if (userAuthId <= 0)
                return ApiResponse<UserActionResponseDto>.FailResponse("Invalid user ID.");

            if (userAuthId == 1)
                return ApiResponse<UserActionResponseDto>.FailResponse("Cannot block admin user.");

            try
            {
                var result = await _repository.BlockUserAsync(userAuthId);

                if (result.Result == "Success")
                    return ApiResponse<UserActionResponseDto>.SuccessResponse(result, result.Message);
                else
                    return ApiResponse<UserActionResponseDto>.FailResponse(result.Message);
            }
            catch (Exception ex)
            {
                return ApiResponse<UserActionResponseDto>.FailResponse($"Error blocking user: {ex.Message}");
            }
        }

        public async Task<ApiResponse<UserActionResponseDto>> UnblockUserAsync(int userAuthId)
        {
            if (userAuthId <= 0)
                return ApiResponse<UserActionResponseDto>.FailResponse("Invalid user ID.");

            if (userAuthId == 1)
                return ApiResponse<UserActionResponseDto>.FailResponse("Cannot unblock admin user.");

            try
            {
                var result = await _repository.UnblockUserAsync(userAuthId);

                if (result.Result == "Success")
                    return ApiResponse<UserActionResponseDto>.SuccessResponse(result, result.Message);
                else
                    return ApiResponse<UserActionResponseDto>.FailResponse(result.Message);
            }
            catch (Exception ex)
            {
                return ApiResponse<UserActionResponseDto>.FailResponse($"Error unblocking user: {ex.Message}");
            }
        }

        public async Task<ApiResponse<UserActionResponseDto>> DeleteUserAsync(int userAuthId)
        {
            if (userAuthId <= 0)
                return ApiResponse<UserActionResponseDto>.FailResponse("Invalid user ID.");

            if (userAuthId == 1)
                return ApiResponse<UserActionResponseDto>.FailResponse("Cannot delete admin user.");

            try
            {
                var result = await _repository.DeleteUserAsync(userAuthId);

                if (result.Result == "Success")
                    return ApiResponse<UserActionResponseDto>.SuccessResponse(result, result.Message);
                else
                    return ApiResponse<UserActionResponseDto>.FailResponse(result.Message);
            }
            catch (Exception ex)
            {
                return ApiResponse<UserActionResponseDto>.FailResponse($"Error deleting user: {ex.Message}");
            }
        }
    }
}