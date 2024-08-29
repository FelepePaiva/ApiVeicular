using ApiVeicular.Models;

namespace ApiVeicular.Repositorys
{
    public interface IVehicleRepository
    {
        void AddVehicle(VehicleModel vehicle);
        VehicleModel GetVehicleById(int vehicleId);
        List<VehicleModel> GetAllVehicles();
        bool DeleteVehicleById(int vehicleId);
        List<VehicleModel> GetVehicleByModel(string model);
        List<VehicleModel> GetVehiclesByManufactorer(string manufacturer);
        List<VehicleModel> GetVehiclesByPriceRange(double inicialPrice, double finalPrice);

    }
}
