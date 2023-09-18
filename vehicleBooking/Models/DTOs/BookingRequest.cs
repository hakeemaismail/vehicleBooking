namespace vehicleBooking.Models.DTOs
{
    public class BookingRequest
    {
        public long VehicleId { get; set; }
        public List<long> SelectedAmenityIds { get; set; }
        public BookingDTO Booking { get; set; }
    }
}
