using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;

namespace vehicleBooking.Repository.Interfaces
{
    public interface IAdminRepository
    {
        bool CreateChauffeur(Chauffeur chauffeur);
        List<Passenger> GetPassengers();
        Passenger GetPassenger(long id);
        bool UpdatePassenger(Passenger passenger);
        bool DeletePassenger(long id);
        List<Chauffeur> GetChauffeurs();
        Chauffeur GetChauffeur(long id);
        bool UpdateChauffeur(Chauffeur chauffeur);  
        bool DeleteChauffeur(long id);
        Chauffeur UpdateAvailability(long chauffeurId, bool status);
        Chauffeur AssignVehicleToChauffeur(long vehicleId, long chauffeurId);
        Chauffeur UpdateVehicleInformation(VehicleDTO vehicle, long id);
        Booking getBookingById (long id);
        List<Booking> GetBookings();
        List<Vehicle> GetVehicles();
        List<Vehicle> filterVehicles(string term);
        List<Booking> filterBookings(string term);
        List<Passenger> filterPassenger(string term);
        Vehicle GetVehicle(long id);
        //Vehicle addVehicle(VehicleDTO vehicle);
        List<Booking> viewBookingsOfASpecificPassenger(long id);
        List<Vehicle> viewAvailableVehicles(bool status);

    }
}
