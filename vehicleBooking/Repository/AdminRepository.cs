using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleBooking.Data;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;
using vehicleBooking.Repository.Interfaces;

namespace vehicleBooking.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateChauffeur(Chauffeur chauffeur)
        {
            _context.Add(chauffeur);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteChauffeur(long id)
        {
            throw new NotImplementedException();
        }

        public Chauffeur GetChauffeur(long id)
        {
            throw new NotImplementedException();
        }

        public List<Chauffeur> GetChauffeurs()
        { 
            List<Chauffeur> list =  _context.Chauffeur.ToList();
            return list;
        }

        public bool DeletePassenger(long id)
        {
            throw new NotImplementedException();
        }

        public Booking getBookingById(long id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookings()
        {
            throw new NotImplementedException();
        }

        public Passenger GetPassenger(long id)
        {
            throw new NotImplementedException();
        }

        public List<Passenger> GetPassengers()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicle(long id)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public bool UpdateChauffeur(Chauffeur chauffeur)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePassenger(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> ViewAvailableVehicles(bool status)
        {
            throw new NotImplementedException();
        }

        public Chauffeur UpdateAvailability(long chauffeurId, bool status)
        {
            var chauffeur = _context.Chauffeur.FirstOrDefault(c => c.Id == chauffeurId);

            if (chauffeur != null)
            {
                chauffeur.AvailabiltyStatus = status;
                _context.SaveChanges();
                return chauffeur;
            }
            return new Chauffeur();
        }

        public Chauffeur AssignVehicleToChauffeur(long vehicleId, long chauffeurId)
        {
            var vehicleChauffeur = new VehicleChauffeur
            {
                VehicleId = vehicleId,
                ChauffeurId = chauffeurId
            };

            _context.VehicleChauffeurs.Add(vehicleChauffeur);
            _context.SaveChanges();
           
            throw new NotImplementedException();
        }

        public Chauffeur UpdateVehicleInformation(VehicleDTO vehicle, long id)
        {
            throw new NotImplementedException();
        }

        public Vehicle addVehicle(VehicleDTO vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> filterVehicles(string term)
        {
            throw new NotImplementedException();
        }

        public List<Booking> filterBookings(string term)
        {
            throw new NotImplementedException();
        }

        public List<Passenger> filterPassenger(string term)
        {
            throw new NotImplementedException();
        }

        public List<Booking> viewBookingsOfASpecificPassenger(long PassengerId)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> viewAvailableVehicles(bool status)
        {
            var vehicle = _context.Vehicle.Where(c => c.Availablity == status).ToList();

            return vehicle;

            
        }
    }
}
