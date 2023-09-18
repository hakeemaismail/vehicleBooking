using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;

namespace vehicleBooking.Repository.Interfaces
{
    public interface IBookingRepository
    {
        Vehicle SelectVehicle(long vehicleId);
        bool makeABooking(long vehicleId, List<long> selectedAmenityIds, BookingDTO booking);
        List<Vehicle> GetAllVehicles();
        List<Amenities> GetAllAmenities(long vehicleId);
       bool SelectAmenities(long vehicleId, List<long> selectedAmenityIds);

    }
}
