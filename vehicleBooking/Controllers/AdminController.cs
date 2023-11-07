using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;
using vehicleBooking.Models.Enums;
using vehicleBooking.Repository;
using vehicleBooking.Repository.Interfaces;

namespace vehicleBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;

        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        //chauffeur
        [HttpPost("createChauffeur")]
        public async Task<ActionResult<Chauffeur>> CreateChauffeur(ChauffeurDto chauffeurDto)
        {
            var Chauffeur = new Chauffeur
            {
                FirstName = chauffeurDto.FirstName,
                LastName = chauffeurDto.LastName,
                Gender = chauffeurDto.Gender,
                Email = chauffeurDto.Email,
                Password = chauffeurDto.Password,
            };

            _repository.CreateChauffeur(Chauffeur);
            return Ok(Chauffeur);
        }

        [HttpGet("getAllChauffeurs")]
        public async Task<ActionResult<List<Chauffeur>>> GetAllChauffeurs()
        {
            return _repository.GetChauffeurs();
        }

        [HttpGet("getAChauffeur")]
        public IActionResult GetChauffeurById(long id)
        {
            var chauffeur = _repository.GetChauffeur(id);

            if (chauffeur == null)
            {
                return NotFound("Chauffeur Not Found");
            }

            return Ok(chauffeur);
        }


        [HttpPut("updateChauffeur/{chauffeurId}")]
        public IActionResult UpdateChauffeur(long chauffeurId, ChauffeurDto updatedChauffeur)
        {
            var chauffeur = _repository.GetChauffeur(chauffeurId);

            if (chauffeur == null)
            {
                return NotFound("Chauffeur not found");
            }

            var updated = _repository.UpdateChauffeur(chauffeurId, updatedChauffeur);

            if (updated != null)
            {
                return Ok(updated);
            }

            return StatusCode(500);
        }

        //[HttpPut("updateChauffeur/{chauffeurId}")]
        //public IActionResult UpdateChauffeur(long chauffeurId, Chauffeur updatedChauffeur)
        //{
        //    var chauffeur = _repository.GetChauffeur(chauffeurId);

        //    if (chauffeur == null)
        //    {
        //        return NotFound("Chauffeur not found");
        //    }

        //    var updated = _repository.UpdateChauffeur(chauffeurId, updatedChauffeur);

        //    if (updated != null)
        //    {
        //        return Ok(updated);
        //    }

        //    return StatusCode(500);
        //}

        [HttpPatch("updateAvailability")]
        public IActionResult UpdateAvailabilty(long id, bool status)
        {
            var chauffeur = _repository.UpdateAvailability(id, status);
            if (chauffeur == null)
            {
                return NotFound("Chauffeur not found");
            }
            return Ok(chauffeur);
        }

        [HttpPost("assignVehicle")]
        public IActionResult AssignVehicleToChauffeur(long vehicleId, long chauffeurId)
        {
            bool result = _repository.AssignVehicleToChauffeur(vehicleId, chauffeurId);
            if (result)
            {
                return Ok(result);
            }
            return StatusCode(400);
        }

        [HttpGet("getVehiclesOfAChauffeur")]
        public IActionResult GetVehiclesOfAChauffeur(long chauffeurId)
        {
            var vehicle = _repository.getVehiclesOfAChauffeur(chauffeurId);

            if (vehicle == null || vehicle.Count == 0)
            {
                return NotFound("No vehicles found for this chauffeur or the chauffeur does not exist.");
            }

            return Ok(vehicle);
        }

        [HttpDelete("Deletechauffeur/{id}")]
        public IActionResult DeleteChauffeur(long id)
        {
            var result = _repository.DeleteChauffeur(id);

            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        //vehicle
        [HttpPost("createVehicle")]
        public async Task<ActionResult<Vehicle>> CreateVehicle(VehicleDTO vehicleDto)
        {
            var Vehicle = new Vehicle
            {
                Name = vehicleDto.Name,
                SeatingCapacity = vehicleDto.SeatingCapacity,
                Type = vehicleDto.Type,
                City = vehicleDto.City,
                Location = vehicleDto.Location,
                Availablity = vehicleDto.Availablity,
                Brand = vehicleDto.Brand
            };

            _repository.addVehicle(Vehicle);
            return Ok(Vehicle);
        }  

        [HttpGet("AvailableVehicles")]
        public IActionResult getVehiclesBasedOnAvailability(bool status)
        {
           var vehicles = _repository.viewAvailableVehicles(status);
            return Ok(vehicles);
        }

        [HttpPut("editVehicle")]
        public IActionResult editVehicleDetails(long id, VehicleDTO vehicle)
        {
            var vehicles = _repository.GetVehicle(id);
            if(vehicles == null)
            {
                return NotFound("Vehicle Not found");
            }
            var updated = _repository.editVehicleDetails(id, vehicle);
            if(updated != null)
            {
                return Ok(updated);
            }
            return StatusCode(500);
        }

        [HttpGet("getAllVehicles")]
        public async Task<ActionResult<List<Vehicle>>> GetAllVehicles()
        {
            return _repository.GetVehicles();
        }


        [HttpGet("getVehicleById")]
        public IActionResult GetVehicle(long id)
        {
            var vehicle = _repository.GetVehicle(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpGet("filterVehicles/{City}/{Name}")]
        public IActionResult filterVehicle(string term)
        {
            var filteredVehicles = _repository.filterVehicles(term);
            if (filteredVehicles == null || filteredVehicles.Count == 0)
            {
                return NotFound("No vehicles found for the specified city or name.");
            }

            return Ok(filteredVehicles);
        }

        [HttpGet("filterVehiclesBasedOnType/{vehicleType}")]
        public IActionResult FilterVehiclesBasedOnType(VehicleType vehicleType)
        {
            var filteredVehicles = _repository.filterVehiclesBasedOnType(vehicleType);

            if (filteredVehicles == null || filteredVehicles.Count == 0)
            {
                return NotFound("No vehicles found for the specified type.");
            }

            return Ok(filteredVehicles);
        }

        [HttpGet("filterVehiclesBasedOnBrand/{vehicleBrand}")]
        public IActionResult FilterVehiclesBasedOnBrand(VehicleBrand vehicleBrand)
        {
            var filteredVehicles = _repository.filterVehiclesBasedOnBrand(vehicleBrand);

            if (filteredVehicles == null || filteredVehicles.Count == 0)
            {
                return NotFound("No vehicles found for the specified brand.");
            }

            return Ok(filteredVehicles);
        }


        //bookings

        [HttpGet("viewBookings")]
        public IActionResult ViewBookingsOfASpecificPassenger (long id)
        {
            var booking = _repository.viewBookingsOfASpecificPassenger(id);
            if(booking != null)
            {
                return Ok(booking);
            }
            return NotFound();
        }

        [HttpGet("filterAvailableBookings")]
        public List<Booking> FilterAvailableBookings (bool status)
        {
            return _repository.filterAvailableBookings(status);
        }

        [HttpGet("GetAllBookings")]
        public List<Booking> GetAllBookings()
        {
            return _repository.GetBookings();
        }

        //passenger

        [HttpPost("createPassenger")]
        public IActionResult CreatePassenger(PassengerDTO passenger)
        {
            var Passenger = new Passenger
            {
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Email = passenger.Email,
                Password = passenger.Password,
                PhoneNumber = passenger.PhoneNumber,
                Gender = passenger.Gender,
            };

            _repository.createPassenger(Passenger);
            return Ok(Passenger);
        }

        [HttpPut("updatePassenger")]
        public IActionResult UpdatePassenger(long passengerId,  PassengerDTO passengerDTO)
        {
            var passenger = _repository.GetPassenger(passengerId);

            if(passenger == null)
            {
                return NotFound("Passenger not found");

            }

            var updated = _repository.UpdatePassenger(passengerId, passengerDTO);
            if(updated != null)
            {
                return Ok(updated);
            }
            return StatusCode(500);
        }

        [HttpGet("getAllPassengers")]
        public IActionResult GetAllPassengers()
        {
            var passengers = _repository.GetPassengers();
            return Ok(passengers);
        }

        [HttpGet("getPassengerById")]
        public IActionResult GetPassengerById(long id)
        {
            var passenger = _repository.GetPassenger(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger);
        }

        [HttpGet("filterPassengersBasedOnGender")]
        public IActionResult FilterPassengersBasedOnGender(string gender)
        {
            var filteredPassengers = _repository.filterBasedOnGender(gender);

            if (filteredPassengers == null || filteredPassengers.Count == 0)
            {
                return NotFound("No passengers found");
            }

            return Ok(filteredPassengers);
        }

        [HttpGet("filterPassengersBasedOnEmail")]
        public IActionResult FilterPassengersBasedOnEmail(string email)
        {
            var passenger = _repository.filterBasedOnEmail(email);

            if (passenger == null)
            {
              return NotFound("No passengers found with that email address");
            }
            else 
            { 
            return Ok(passenger);
            }
        }


    }
}
