
using BookingApp.Application.Common;
using BookingApp.Application.DTOs.Admin;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IUserManagementService
    {
        Task<ApiResponse<PaginatedResponseDto<UserManagementDto>>> GetUsersAsync(PaginationRequestDto request);
        Task<ApiResponse<UserActionResponseDto>> BlockUserAsync(int userAuthId);
        Task<ApiResponse<UserActionResponseDto>> UnblockUserAsync(int userAuthId);
        Task<ApiResponse<UserActionResponseDto>> DeleteUserAsync(int userAuthId);
    }
}