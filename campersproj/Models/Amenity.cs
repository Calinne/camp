
namespace campersproj.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SpotsAmenities> SpotsAmenities { get; set; }
    }
}
