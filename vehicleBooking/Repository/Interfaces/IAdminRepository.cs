using Microsoft.AspNetCore.Mvc;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;
using vehicleBooking.Models.Enums;

namespace vehicleBooking.Repository.Interfaces
{
    public interface IAdminRepository
    {
        //chauffeurs
        bool CreateChauffeur(Chauffeur chauffeur); //done
        List<Chauffeur> GetChauffeurs(); //done
        Chauffeur GetChauffeur(long id);
        Chauffeur UpdateChauffeur(long id, ChauffeurDto chauffeurDto);
        //Chauffeur UpdateChauffeur(long id);
        //Chauffeur UpdateChauffeur(long id, Chauffeur chauffeur);
        bool DeleteChauffeur(long id);
        Chauffeur UpdateAvailability(long chauffeurId, bool status); //done
       bool AssignVehicleToChauffeur(long vehicleId, long chauffeurId); //done
        List<Vehicle> getVehiclesOfAChauffeur(long id); //done

        //passenger

        Passenger createPassenger(Passenger passenger);
        List<Passenger> GetPassengers();
        Passenger GetPassenger(long id);
        Passenger UpdatePassenger(long id, PassengerDTO passengerDTO);
        bool DeletePassenger(long id);
        List<Passenger> filterBasedOnGender(string gender); //done
        Passenger filterBasedOnEmail(string email); //done
        List<Booking> viewBookingsOfASpecificPassenger(long id); //done

        //booking
        Booking getBookingById (long id);
        List<Booking> filterAvailableBookings(bool status); //done
        List<Booking> GetBookings();

        //vehicles
        List<Vehicle> GetVehicles();
        List<Vehicle> filterVehicles(string term);
        List<Vehicle> filterVehiclesBasedOnType(VehicleType vehicleType);
        List<Vehicle> filterVehiclesBasedOnBrand(VehicleBrand vehicleBrand );
        Vehicle GetVehicle(long id);
        bool addVehicle(Vehicle vehicle);        
        List<Vehicle> viewAvailableVehicles(bool status); //done
        Vehicle editVehicleDetails(long vehicleId, VehicleDTO vehicle); //done
        bool deleteVehicle(long vehicleId, bool status);

        //company

        //register a company
        //bool CreateACompany(Company company);

        ////register chauffeurs for a company
        //bool RegisterChauffeurs(long chauffeurId, long companyId);

        ////register vehicles for selected chauffeurs
        //bool RegisterVehiclesToChauffeur(long chauffeurId, long vehicleId);

        //see all chauffeurs and their respective vehicles for a selected company 



    }
}
