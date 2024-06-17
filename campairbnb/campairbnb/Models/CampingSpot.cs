using System.Collections.Generic;

namespace campairbnb.Models
{
    public class CampingSpot
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public double PricePerNight { get; set; } // Change to double
        public List<Image> Images { get; set; }
        public List<SpotsAmenity> SpotsAmenities { get; set; }
    }
}
