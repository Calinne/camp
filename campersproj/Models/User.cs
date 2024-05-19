

namespace campersproj.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
