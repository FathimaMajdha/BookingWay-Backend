

namespace BookingApp.Application.DTOs
{
    public class JwtResponseDto
    {
        public string Token { get; set; } = null!;
        public string Username { get; set; } = null!;

        public string Role { get; set; } = null!;

        public int UserAuthId { get; set; }

        public bool IsBlocked { get; set; }
    }

}
