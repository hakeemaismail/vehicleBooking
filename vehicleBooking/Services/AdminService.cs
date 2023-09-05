using Microsoft.AspNetCore.Mvc;
using vehicleBooking.Data;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;

namespace vehicleBooking.Services
{
    public class AdminService
    {
        private readonly DataContext _context;

        public AdminService(DataContext context)
        {
            _context = context;
        }

        //public async Task<Chauffeur> addChauffeur(ChauffeurDto chauffeurDto)
        //{
            
        //}
    }
}
