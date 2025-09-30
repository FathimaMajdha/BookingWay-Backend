
namespace BookingApp.Domain.Entities
{

    public class UserAuth
    {
        public int UserAuthId { get; set; }   
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public bool IsBlocked { get; set; } = false;
        public DateTime Created_at { get; set; }
        public int Success { get; set; }
    }

}
