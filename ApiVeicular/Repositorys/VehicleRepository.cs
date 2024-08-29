using ApiVeicular.Models;
using ApiVeicular.Contexts;

namespace ApiVeicular.Repositorys
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ConnectionContext _connection = new ConnectionContext();

        public void AddVehicle(VehicleModel vehicle)
        {
            _connection.VehiclesContext.Add(vehicle);
            _connection.SaveChanges();
        }

        public bool DeleteVehicleById(int id)
        {
            var vehicle = _connection.VehiclesContext.Find(id);
            if (vehicle != null)
            {
                _connection.VehiclesContext.Remove(vehicle);
                return true;
            }
            return false;
        }
        public List<VehicleModel> GetAllVehicles()
        {
            return _connection.VehiclesContext.ToList();
        }
        public VehicleModel GetVehicleById(int id)
        {
            var vehicle = _connection.VehiclesContext.Find(id);

            if (vehicle != null)
            {
                return vehicle;
            }
            return null;
        }

        public List<VehicleModel> GetVehicleByModel(string model)
        {
            List<VehicleModel> vehiclesToFind = _connection.VehiclesContext.Where(v =>
            v.Model == model).ToList();
            return vehiclesToFind;
        }

        public List<VehicleModel> GetVehiclesByManufactorer(string manufacturer)
        {
            List<VehicleModel> vehiclesToFind = _connection.VehiclesContext.Where(v =>
            v.Manufactorer == manufacturer).ToList();
            return vehiclesToFind;
        }

        public List<VehicleModel> GetVehiclesByPriceRange(double initialPrice, double finalPrice)
        {
           List<VehicleModel> vehiclesInRange = _connection.VehiclesContext.Where(v => v.Price >= initialPrice &&
           v.Price <= finalPrice).ToList();
           return vehiclesInRange;
        
        }
    }
}  
