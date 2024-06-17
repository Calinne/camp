using LiteDB;
using campairbnb.Models;
using System.Collections.Generic;
using System.Linq;

namespace campairbnb.Data
{
    public class CampAirbnbDatabase : ICampAirbnbDataContext
    {
        private readonly LiteDatabase _db;

        public CampAirbnbDatabase()
        {
            _db = new LiteDatabase(@"campairbnb.db");
        }

        // User Methods
        public void AddUser(User user)
        {
            _db.GetCollection<User>("Users").Insert(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }

        public User GetUser(int id)
        {
            return _db.GetCollection<User>("Users").FindById(id);
        }

        public void DeleteUser(int id)
        {
            _db.GetCollection<User>("Users").Delete(id);
        }

        public void UpdateUser(User user)
        {
            var usersCollection = _db.GetCollection<User>("Users");
            usersCollection.Update(user);
        }

        // CampingSpot Methods
        public void AddCampingSpot(CampingSpot campingSpot)
        {
            var campingSpots = _db.GetCollection<CampingSpot>("CampingSpots");
            campingSpots.Insert(campingSpot);
        }

        public IEnumerable<CampingSpot> GetCampingSpots()
        {
            return _db.GetCollection<CampingSpot>("CampingSpots").FindAll();
        }

        public CampingSpot GetCampingSpot(int id)
        {
            var campingSpots = _db.GetCollection<CampingSpot>("CampingSpots");
            var campingSpot = campingSpots.FindById(id);

            if (campingSpot != null)
            {
                // Get images
                var images = _db.GetCollection<Image>("Images").Find(img => img.CampingSpotId == id).ToList();
                campingSpot.Images = images;

                // Get spot amenities
                var spotsAmenities = _db.GetCollection<SpotsAmenity>("SpotsAmenities").Find(sa => sa.CampingSpotId == id).ToList();
                campingSpot.SpotsAmenities = spotsAmenities;

                // Populate amenities details
                foreach (var sa in spotsAmenities)
                {
                    sa.Amenity = _db.GetCollection<Amenity>("Amenities").FindById(sa.AmenityId);
                }
            }

            return campingSpot;
        }

        public void DeleteCampingSpot(int id)
        {
            _db.GetCollection<CampingSpot>("CampingSpots").Delete(id);
        }

        // Booking Methods
        public void AddBooking(Booking booking)
        {
            _db.GetCollection<Booking>("Bookings").Insert(booking);
        }

        public IEnumerable<Booking> GetBookings()
        {
            return _db.GetCollection<Booking>("Bookings").FindAll();
        }

        public Booking GetBooking(int id)
        {
            return _db.GetCollection<Booking>("Bookings").FindById(id);
        }

        public void DeleteBooking(int id)
        {
            _db.GetCollection<Booking>("Bookings").Delete(id);
        }

        // Amenity Methods
        public void AddAmenity(Amenity amenity)
        {
            _db.GetCollection<Amenity>("Amenities").Insert(amenity);
        }

        public IEnumerable<Amenity> GetAmenities()
        {
            return _db.GetCollection<Amenity>("Amenities").FindAll();
        }

        public Amenity GetAmenity(int id)
        {
            return _db.GetCollection<Amenity>("Amenities").FindById(id);
        }

        public void DeleteAmenity(int id)
        {
            _db.GetCollection<Amenity>("Amenities").Delete(id);
        }

        // SpotsAmenity Methods
        public void AddSpotsAmenity(SpotsAmenity spotsAmenity)
        {
            _db.GetCollection<SpotsAmenity>("SpotsAmenities").Insert(spotsAmenity);
        }

        public IEnumerable<SpotsAmenity> GetSpotsAmenities()
        {
            return _db.GetCollection<SpotsAmenity>("SpotsAmenities").FindAll();
        }

        public SpotsAmenity GetSpotsAmenity(int id)
        {
            return _db.GetCollection<SpotsAmenity>("SpotsAmenities").FindById(id);
        }

        public void DeleteSpotsAmenity(int id)
        {
            _db.GetCollection<SpotsAmenity>("SpotsAmenities").Delete(id);
        }

        // Image Methods
        public void AddImage(Image image)
        {
            _db.GetCollection<Image>("Images").Insert(image);
        }

        public IEnumerable<Image> GetImages(int campingSpotId)
        {
            return _db.GetCollection<Image>("Images").Find(img => img.CampingSpotId == campingSpotId);
        }

        public void DeleteImage(int id)
        {
            _db.GetCollection<Image>("Images").Delete(id);
        }
    }
}
