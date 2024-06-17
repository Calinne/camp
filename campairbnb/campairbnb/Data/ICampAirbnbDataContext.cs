using campairbnb.Models;
using System.Collections.Generic;

namespace campairbnb.Data
{
    public interface ICampAirbnbDataContext
    {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);

        void AddCampingSpot(CampingSpot campingSpot);
        IEnumerable<CampingSpot> GetCampingSpots();
        CampingSpot GetCampingSpot(int id);
        void DeleteCampingSpot(int id);
        IEnumerable<CampingSpot> GetCampingSpotsByOwner(int ownerId);


        //booking
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int id);
        void DeleteBooking(int id);
        IEnumerable<dynamic> GetBookingsWithCampingSpotDetails();

        void AddAmenity(Amenity amenity);
        IEnumerable<Amenity> GetAmenities();
        Amenity GetAmenity(int id);
        void DeleteAmenity(int id);

        void AddSpotsAmenity(SpotsAmenity spotsAmenity);
        IEnumerable<SpotsAmenity> GetSpotsAmenities();
        SpotsAmenity GetSpotsAmenity(int id);
        void DeleteSpotsAmenity(int id);

        void AddImage(Image image);
        IEnumerable<Image> GetImages(int campingSpotId);
        void DeleteImage(int id);
    }
}
