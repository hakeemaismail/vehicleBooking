using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;
using vehicleBooking.Repository.Interfaces;

namespace vehicleBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet("viewAllVehicles")]
        public IActionResult ViewAllVehicles()
        {
            return Ok(_bookingRepository.GetAllVehicles());
        }

        [HttpPost("selectVehicle")]
        public IActionResult SelectVehicleID(long vehicleId)
        {
            var vehicle = _bookingRepository.SelectVehicle(vehicleId);

            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpGet("viewAmenitiesOfAVehicle")]
        public IActionResult ViewAmentiesForAVehicle(long vehicleId)
        {
            var amenities = _bookingRepository.GetAllAmenities(vehicleId);
            if (amenities != null)
            {
                return Ok(amenities);
            }
            return NotFound("No amenities found for this vehicle");
        }

        [HttpPost("makeABooking")]
        public IActionResult MakeABooking([FromBody] BookingRequest request)
        {
            var result = _bookingRepository.makeABooking(request.VehicleId, request.SelectedAmenityIds, request.Booking);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

        }



    }
}
