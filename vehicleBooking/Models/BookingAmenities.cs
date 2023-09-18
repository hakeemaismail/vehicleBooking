namespace vehicleBooking.Models
{
    public class BookingAmenities
    {
        public long BookingId { get; set; }
        public long AmenityId { get; set; }
        public Booking Booking { get; set; }
        public Amenities Amenities { get; set; }
    }
}
