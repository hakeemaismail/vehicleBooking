using Microsoft.EntityFrameworkCore;
using vehicleBooking.Models;

namespace vehicleBooking.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Chauffeur> Chauffeur { get; set;}
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Billing> Billing { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
