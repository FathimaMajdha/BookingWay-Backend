using BookingApp.Application.DTOs.Admin;
using BookingApp.Application.Interfaces.Admin;
using Dapper;
using System.Data;

namespace BookingApp.Infrastructure.Repositories
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly IDbConnection _connection;

        public UserManagementRepository(IDbConnection connection)
        {
            _connection = connection;
        }

       
               public async Task<PaginatedResponseDto<UserManagementDto>> GetUsersAsync(PaginationRequestDto request)
        {
            try
            {
                using var multi = await _connection.QueryMultipleAsync(
                    "sp_GetDashboardUsers",
                    new
                    {
                        Flag = 1,
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                        SearchTerm = string.IsNullOrWhiteSpace(request.SearchTerm) ? null : request.SearchTerm,
                        SortColumn = string.IsNullOrWhiteSpace(request.SortColumn) ? "Created_At" : request.SortColumn,
                        SortDirection = string.IsNullOrWhiteSpace(request.SortDirection) ? "DESC" : request.SortDirection
                    },
                    commandType: CommandType.StoredProcedure
                );
                var totalCount = await multi.ReadFirstOrDefaultAsync<int>();

                
                var users = (await multi.ReadAsync<UserManagementDto>()).ToList();

                Console.WriteLine($"Raw users from database: {users.Count}");
                foreach (var user in users)
                {
                    Console.WriteLine($"User: {user.UserAuthId}, {user.Username}, {user.Email}");
                }

                
                var validUsers = users
                    .Where(u => u != null &&
                               u.UserAuthId > 1 &&
                               !string.IsNullOrWhiteSpace(u.Username) &&
                               !string.IsNullOrWhiteSpace(u.Email))
                    .ToList();

                Console.WriteLine($"Valid users after filtering: {validUsers.Count}");

                
                if (validUsers.Count == 0)
                {
                    return new PaginatedResponseDto<UserManagementDto>
                    {
                        Data = new List<UserManagementDto>(),
                        TotalCount = 0,
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize
                    };
                }

               
                var bookings = new List<UserBookingDetailDto>();
                try
                {
                    bookings = (await multi.ReadAsync<UserBookingDetailDto>())
                        .Where(b => b.UserAuthId > 1)
                        .ToList();
                }
                catch
                {
                    
                }

                
                foreach (var user in validUsers)
                {
                    user.Bookings = bookings
                        .Where(b => b.UserAuthId == user.UserAuthId)
                        .OrderByDescending(b => b.BookingDate)
                        .ToList();
                }

                return new PaginatedResponseDto<UserManagementDto>
                {
                    Data = validUsers,
                    TotalCount = totalCount,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUsersAsync: {ex.Message}");
                
                return new PaginatedResponseDto<UserManagementDto>
                {
                    Data = new List<UserManagementDto>(),
                    TotalCount = 0,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize
                };
            }
        }
        public async Task<UserActionResponseDto> BlockUserAsync(int userAuthId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<UserActionResponseDto>(
                "sp_GetDashboardUsers",
                new
                {
                    Flag = 2,
                    UserAuthId = userAuthId
                },
                commandType: CommandType.StoredProcedure
            );

            return result ?? new UserActionResponseDto { Result = "Error", Message = "Failed to block user" };
        }

        public async Task<UserActionResponseDto> UnblockUserAsync(int userAuthId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<UserActionResponseDto>(
                "sp_GetDashboardUsers",
                new
                {
                    Flag = 3,
                    UserAuthId = userAuthId
                },
                commandType: CommandType.StoredProcedure
            );

            return result ?? new UserActionResponseDto { Result = "Error", Message = "Failed to unblock user" };
        }

        public async Task<UserActionResponseDto> DeleteUserAsync(int userAuthId)
        {
            var result = await _connection.QueryFirstOrDefaultAsync<UserActionResponseDto>(
                "sp_GetDashboardUsers",
                new
                {
                    Flag = 4,
                    UserAuthId = userAuthId
                },
                commandType: CommandType.StoredProcedure
            );

            return result ?? new UserActionResponseDto { Result = "Error", Message = "Failed to delete user" };
        }
    }
}