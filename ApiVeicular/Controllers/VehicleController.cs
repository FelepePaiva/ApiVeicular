using ApiVeicular.Models;
using ApiVeicular.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Security;

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
        [HttpDelete("delete{id}")]
        public IActionResult DeleteVehicleById(int id)
        {
            var vehicle = _vehicleRepository.DeleteVehicleById(id);
            if (vehicle)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpGet("model/{model}")]
        public IActionResult GetVehiclesByModel(string model)
        {
            List<VehicleModel> vehicleModels = _vehicleRepository.GetVehicleByModel(model);
            if (vehicleModels.Count == 0)
            {
                return NotFound();
            }
            return Ok(vehicleModels);
        }
        [HttpGet("manufacturer/{manufacturer}")]
        public IActionResult GetVehiclesByManufacturer(string manufacturer)
        {
            List<VehicleModel> vehicleByManufacturer = _vehicleRepository.GetVehiclesByManufactorer(manufacturer);
            if (vehicleByManufacturer.Count == 0)
            {
                return NotFound();
            }
            return Ok(vehicleByManufacturer);
        }
        [HttpGet("pricebyrange/{initialPrice}/{finalPrice}")]
        public IActionResult GetVehiclesByPriceRange(double initialPrice, double finalPrice)
        {
            List<VehicleModel> vehiclesInPriceRange = _vehicleRepository.
                GetVehiclesByPriceRange(initialPrice, finalPrice);
            if (vehiclesInPriceRange.Count == 0)
            {
                return NotFound();
            }
            return Ok(vehiclesInPriceRange);
        }
    }
}