namespace TARge22Cars.Models.Cars
{
    public class CarsCreateUpdateViewModel
    {
        public Guid CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public string Power { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; }
        public string Fuel { get; set; }
        public int FuelConsumption { get; set; }
        public int Mileage { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
