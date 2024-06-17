using System;
using LiteDB;

namespace campairbnb.Models
{
    public class User
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; } // owner or user
    }
}

