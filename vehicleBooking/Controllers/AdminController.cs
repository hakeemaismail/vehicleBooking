using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vehicleBooking.Models;
using vehicleBooking.Models.DTOs;
using vehicleBooking.Repository;
using vehicleBooking.Repository.Interfaces;
using vehicleBooking.Services;

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

        [HttpPost]
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

        [HttpGet]
        public async Task<ActionResult<List<Chauffeur>>> GetAllChauffeurs()
        {
            return _repository.GetChauffeurs();
        }

        [HttpPatch]
        public Chauffeur UpdateAvailabilty(long id, bool status)
        {
            return _repository.UpdateAvailability(id, status);
        }
    }
}
