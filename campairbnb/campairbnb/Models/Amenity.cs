using System;
using LiteDB;

namespace campairbnb.Models
{
    public class Amenity
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
       // public int CampingSpotId { get; set; }

        //for many to may relationship :
        public ICollection<SpotsAmenity> SpotsAmenities { get; set; }
    }

}

