using ApiVeicular.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVeicular.Contexts
{
    public class ConnectionContext : DbContext
    {
        public DbSet<VehicleModel> VehiclesContext { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(
        "Server=localhost;" +
        "Port=5432;Database=postgres;" +
        "User Id = postgres;" +
        "Password=1234567"
        );
    }
}
