using System;
using LiteDB;

namespace campairbnb.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CampingSpotId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float TotalPrice { get; set; }
      //  public string Status { get; set; } // "confirmed" or "pending"
    }
}
