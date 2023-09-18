using vehicleBooking.Data;
using vehicleBooking.Models;
using vehicleBooking.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using vehicleBooking.Models.DTOs;

namespace vehicleBooking.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _context;
        public BookingRepository(DataContext context)
        {
            _context = context;
        }
        public List<Amenities> GetAllAmenities(long vehicleId)
        { 
            List<Amenities> amenities = _context.VehicleAmenities.Where(vc => vc.VehicleId == vehicleId).Select(v => v.Amenities).ToList();
            return amenities;
        }
        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = _context.Vehicle.ToList();
            return vehicles;
        }
       

        public List<VehicleAmenities> SelectAmenities(long vehicleId)
        {
            throw new NotImplementedException();
        }

        //public bool SelectAmenities(long vehicleId, List<long> selectedAmenityIds)
        //{
        //    var vehicle = _context.Vehicle.FirstOrDefault(x => x.Id == vehicleId);
        //    if (vehicle == null)
        //    {
        //        return false;
        //    }

        //    foreach(var amenityId in selectedAmenityIds) 
        //    {
        //        var amenity = _context.Amenities.FirstOrDefault(c => c.Id == amenityId);
        //        if (amenity != null) 
        //        {
        //            var vehicleAmenities = new VehicleAmenities
        //            {
        //                AmenityId = amenityId,
        //                VehicleId = vehicleId
        //            };
        //            _context.VehicleAmenities.Add(vehicleAmenities);
        //        }
        //    }
        //    _context.SaveChanges();
        //    return true;
        //}

        public bool makeABooking(long vehicleId, List<long> selectedAmenityIds, BookingDTO booking)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(x => x.Id == vehicleId);
            if (vehicle == null)
            {
                return false;
            }

            var newBooking = new Booking
            {
                PickupLocation = booking.PickupLocation,
                DropoffLocation = booking.DropoffLocation,
                SpecialRequest = booking.SpecialRequest,
                Date = booking.Date,
                Time = booking.Time,
                VehicleId = vehicleId,
               
            };
            _context.Bookings.Add(newBooking);
            _context.SaveChanges();

            foreach (var amenityId in selectedAmenityIds)
            {
                var amenity = _context.Amenities.FirstOrDefault(c => c.Id == amenityId);
                if (amenity != null)
                {
                    var bookingAmenities = new BookingAmenities
                    {
                        AmenityId = amenityId,
                        BookingId = newBooking.Id
                    };
                    _context.BookingAmenities.Add(bookingAmenities);
                }      
            }
            _context.SaveChanges();
            return true;

        }
        public Vehicle SelectVehicle(long vehicleId)
        {  
            var vehicle = _context.Vehicle.FirstOrDefault(x => x.Id == vehicleId);
            return vehicle;
        }


    }
}
