

namespace campersproj.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CampingSpotId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public User User { get; set; }
        public CampingSpot CampingSpot { get; set; }
    }
}
