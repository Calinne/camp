using System;
using LiteDB;

namespace campairbnb.Models
{
    //public class Image
    //{
    //    [BsonId]
    //    public int Id { get; set; }
    //    public string ImageName { get; set; }
    //    public int CampingSpotId { get; set; }
    //}

    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; } // Path or filename
        public byte[] ImageData { get; set; } // Binary data for the image
        public int CampingSpotId { get; set; }
    }

}

