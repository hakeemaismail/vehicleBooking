using vehicleBooking.Models;

namespace vehicleBooking.Repository.Interfaces
{
    public interface IPassengerRepository
    {
        bool UpdatePassenger(Passenger passenger);
        Chauffeur GetChauffeur(int vehicleId);

    }
}
