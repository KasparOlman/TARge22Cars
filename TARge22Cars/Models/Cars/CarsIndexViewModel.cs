namespace TARge22Cars.Models.Cars
{
    public class CarsIndexViewModel
    {
        public Guid CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime Year { get; set; }
        public string Transmission { get; set; }
        public string Drivetrain { get; set; }
        public string Fuel { get; set; }
        public int Mileage { get; set; }
    }
}
