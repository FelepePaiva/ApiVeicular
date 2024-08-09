namespace ApiVeicular.Models
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufactorer { get; set; }
        public string Color { get; set; }
        public int YearModel { get; set; }
        public double Price { get; set; }

        public VehicleDto() { }

        public VehicleDto(string model, string manufactorer, string color, int yearModel, double price)
        {
            Model = model;
            Manufactorer = manufactorer;
            Color = color;
            YearModel = yearModel;
            Price = price;
        }
    }
}
