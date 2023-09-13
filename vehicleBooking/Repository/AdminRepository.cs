using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleBooking.Data;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;
using vehicleBooking.Models.Enums;
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

        //Chauffeur
        public bool CreateChauffeur(Chauffeur chauffeur)
        {
            _context.Add(chauffeur);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteChauffeur(long id)
        {
            var chauffeur = _context.Chauffeur.FirstOrDefault(c => c.Id == id);

            if (chauffeur != null)
            {
                _context.Chauffeur.Remove(chauffeur);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Chauffeur GetChauffeur(long id)
        {
           return _context.Chauffeur.FirstOrDefault(c => c.Id == id);       
        }

        public List<Chauffeur> GetChauffeurs()
        { 
            List<Chauffeur> list =  _context.Chauffeur.ToList();
            return list;
        }

        public Chauffeur UpdateChauffeur(long chauffeurId, ChauffeurDto updatedChauffeur)
        {
            var chauffeur = GetChauffeur(chauffeurId);

            if (chauffeur != null)
            {
                chauffeur.FirstName = updatedChauffeur.FirstName;
                chauffeur.LastName = updatedChauffeur.LastName;
                chauffeur.Email = updatedChauffeur.Email;
                chauffeur.Gender = updatedChauffeur.Gender;
                chauffeur.Password = updatedChauffeur.Password;
                chauffeur.AvailabiltyStatus = updatedChauffeur.AvailabiltyStatus;
                chauffeur.phoneNumber = updatedChauffeur.phoneNumber;
                _context.SaveChanges();
            }

            return chauffeur; 
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

        public bool AssignVehicleToChauffeur(long vehicleId, long chauffeurId)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(v => v.Id == vehicleId);
            var chauffeur = _context.Chauffeur.FirstOrDefault(c => c.Id == chauffeurId);

            if (vehicle == null || chauffeur == null)
            {
                return false;
            }

            var existingRecord = _context.VehicleChauffeurs
        .FirstOrDefault(vc => vc.VehicleId == vehicleId && vc.ChauffeurId == chauffeurId);

            if (existingRecord != null)
            {
                return false;
            }
            var vehicleChauffeur = new VehicleChauffeur
            {
                VehicleId = vehicleId,
                ChauffeurId = chauffeurId
            };

            _context.VehicleChauffeurs.Add(vehicleChauffeur);
            _context.SaveChanges();
            return true;
        }
        public List<Vehicle> getVehiclesOfAChauffeur(long id)
        {
            var vehicles = _context.VehicleChauffeurs.Where(vc => vc.ChauffeurId == id).Select(v => v.Vehicle).ToList();
            return vehicles;
        }


        //Passenger

        public Passenger createPassenger(Passenger passenger)
        {
            _context.Add(passenger);
            _context.SaveChanges();
            return passenger;
        }
        public bool DeletePassenger(long id)
        {
            var passenger = _context.Passenger.FirstOrDefault(p => p.Id == id);

            if (passenger != null)
            {
                _context.Passenger.Remove(passenger);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public Passenger GetPassenger(long id)
        {
           var passenger = _context.Passenger.FirstOrDefault(p => p.Id == id);
            return passenger;
        }

        public List<Passenger> GetPassengers()
        {
            var passenger = _context.Passenger.ToList();
            return passenger;
        }

        public Passenger UpdatePassenger(long id, PassengerDTO passengerDto )
        {
            var passenger = GetPassenger(id);

            if(passenger != null)
            {
                passenger.FirstName = passengerDto.FirstName;
                passenger.LastName = passengerDto.LastName;
                passenger.Email = passengerDto.Email;
                passenger.Gender = passengerDto.Gender;
                passenger.PhoneNumber = passengerDto.PhoneNumber;
                passenger.Password = passengerDto.Password;
                _context.SaveChanges();
            }
            return passenger;
        }
        public List<Passenger> filterBasedOnGender(string gender)
        {
            var filteredPassengers = _context.Passenger.Where(p => p.Gender == gender).ToList();
            return filteredPassengers;
        }
        public Passenger filterBasedOnEmail(string email)
        {
            var passenger = _context.Passenger.Where(p => p.Email == email).FirstOrDefault();
            return passenger;
        }


        //Bookings
        public Booking getBookingById(long id)
        {
            return _context.Bookings.FirstOrDefault(c => c.Id == id);
        }
       
        public List<Booking> GetBookings()
        {
            return _context.Bookings.ToList();
        }
        public List<Booking> filterAvailableBookings (bool status)
        {
            var bookings = _context.Bookings.Where(c => c.isCompleted == status).ToList();
            return bookings;
        }
        public List<Booking> viewBookingsOfASpecificPassenger(long PassengerId)
        {
            var passenger = _context.Passenger.Include(p => p.bookings)
        .FirstOrDefault(p => p.Id == PassengerId);


            if (passenger != null)
            {
                List<Booking> passengerBookings = passenger.bookings.ToList();
                return passengerBookings;
            }
            return new List<Booking>();
        }

        //Vehicles

        public Vehicle GetVehicle(long id)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(p => p.Id == id);
            return vehicle;
        }

        public List<Vehicle> GetVehicles()
        {
            var vehicle = _context.Vehicle.ToList();
            return vehicle;
        }  
      
        public bool addVehicle(Vehicle vehicle)
        {
            _context.Add(vehicle);
            _context.SaveChanges();
            return true;
        }

        public List<Vehicle> filterVehicles(string term)
        {
            var vehicle = _context.Vehicle.Where(p => p.City == term || p.Name == term).ToList();
            return vehicle;
        }
        public List<Vehicle> viewAvailableVehicles(bool status)
        {
            var vehicle = _context.Vehicle.Where(c => c.Availablity == status).ToList();

            return vehicle;
        }   
        public Vehicle editVehicleDetails(long vehicleId, VehicleDTO vehicleDTO)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(c => c.Id == vehicleId);
            if(vehicle != null)
            {
                vehicle.Name = vehicleDTO.Name;
                vehicle.SeatingCapacity = vehicleDTO.SeatingCapacity;
                vehicle.City = vehicleDTO.City;
                vehicle.Availablity = vehicleDTO.Availablity;
                vehicle.Type = vehicleDTO.Type;
                vehicle.Brand = vehicleDTO.Brand;

                _context.SaveChanges();
                return vehicle;
            }
            return new Vehicle();
        }

        public bool deleteVehicle(long vehicleId, bool status)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(p => p.Id == vehicleId);
            if(vehicle != null)
            {
                vehicle.isActive = false;
                return true;
            }
            return false;
        }

        public List<Vehicle> filterVehiclesBasedOnType(VehicleType vehicleType)
        {
            var vehicle = _context.Vehicle.Where(v => v.Type == vehicleType).ToList();
            return vehicle;
        }

        public List<Vehicle> filterVehiclesBasedOnBrand(VehicleBrand vehicleBrand)
        {
            var vehicle = _context.Vehicle.Where(v => v.Brand == vehicleBrand).ToList();
            return vehicle;
        }

    }
}
