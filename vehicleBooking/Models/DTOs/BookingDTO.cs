namespace vehicleBooking.Models.DTOs
{
    public class BookingDTO
    {
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public string? SpecialRequest { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public long VehicleId { get; set; }
    }
}
