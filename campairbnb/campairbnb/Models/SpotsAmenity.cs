using System;
using LiteDB;

namespace campairbnb.Models
{
    public class SpotsAmenity
    {
        public int Id { get; set; }
        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
        public int CampingSpotId { get; set; }
        // public CampingSpot CampingSpot { get; set; }
    }
}

