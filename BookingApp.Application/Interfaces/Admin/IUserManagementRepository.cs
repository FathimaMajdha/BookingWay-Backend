
using BookingApp.Application.DTOs.Admin;
using System.Threading.Tasks;

namespace BookingApp.Application.Interfaces.Admin
{
    public interface IUserManagementRepository
    {
        Task<PaginatedResponseDto<UserManagementDto>> GetUsersAsync(PaginationRequestDto request);
        Task<UserActionResponseDto> BlockUserAsync(int userAuthId);
        Task<UserActionResponseDto> UnblockUserAsync(int userAuthId);
        Task<UserActionResponseDto> DeleteUserAsync(int userAuthId);
    }
}