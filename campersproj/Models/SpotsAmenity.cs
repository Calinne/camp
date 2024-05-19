

namespace campersproj.Models
{
    public class SpotsAmenities
    {
        public int Id { get; set; }
        public int CampingSpotId { get; set; }

        public CampingSpot CampingSpot { get; set; }
        public Amenity Amenity { get; set; }
    }
}
