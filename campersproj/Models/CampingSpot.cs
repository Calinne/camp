

namespace campersproj.Models
{
    public class CampingSpot
    {
        public int Id { get; set; }
        public int OwnerId { get; set; } //to navigate
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  //pricepernight

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<SpotsAmenities> SpotsAmenities { get; set; }
    }
}
