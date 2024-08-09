using ApiVeicular.Models;
using ApiVeicular.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace ApiVeicular.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleDto vehicleDto)
        {
            var vehicle = new VehicleModel(vehicleDto.Model, vehicleDto.Manufactorer,
                vehicleDto.Color, vehicleDto.YearModel, vehicleDto.Price);
            _vehicleRepository.AddVehicle(vehicle);
            return Ok(vehicle);
        }
        [HttpGet]
        public IActionResult GetAllVehicle()
        {
            var vehicles = _vehicleRepository.GetAllVehicles();
            return Ok(vehicles);
        }
        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = _vehicleRepository.GetVehicleById(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVehicleById(int id)
        {
            var vehicle = _vehicleRepository.DeleteVehicleById(id);
            if (vehicle)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}