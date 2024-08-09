using ApiVeicular.Models;

namespace ApiVeicular.Repositorys
{
    public interface IVehicleRepository
    {
        void AddVehicle(VehicleModel vehicle);
        VehicleModel GetVehicleById(int vehicleId);
        List<VehicleModel> GetAllVehicles();
        bool DeleteVehicleById(int vehicleId);
    }
}
