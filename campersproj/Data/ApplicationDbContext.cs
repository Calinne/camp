using campersproj.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace campersproj.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CampingSpot> CampingSpots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<SpotsAmenities> SpotsAmenities { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Booking>()
        //        .HasOne(b => b.User)
        //        .WithMany(u => u.Bookings)
        //        .HasForeignKey(b => b.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<Booking>()
        //        .HasOne(b => b.CampingSpot)
        //        .WithMany(cs => cs.Bookings)
        //        .HasForeignKey(b => b.CampingSpotId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    modelBuilder.Entity<SpotsAmenities>()
        //        .HasKey(sa => new { sa.AmenityId, sa.CampingSpotId });

        //    modelBuilder.Entity<SpotsAmenities>()
        //        .HasOne(sa => sa.CampingSpot)
        //        .WithMany(cs => cs.SpotsAmenities)
        //        .HasForeignKey(sa => sa.CampingSpotId);

        //    modelBuilder.Entity<SpotsAmenities>()
        //        .HasOne(sa => sa.Amenity)
        //        .WithMany(a => a.SpotsAmenities)
        //        .HasForeignKey(sa => sa.AmenityId);

        //    base.OnModelCreating(modelBuilder);






    }
}
