using TARge22Cars.Core.Dto;

namespace TARge22Cars.Models.Cars
{
    public class CarsCreateUpdateViewModel
    {
        public Guid? CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string Power { get; set; }
        public TransmissionType Transmission { get; set; }
        public string Drivetrain { get; set; }
        public string Fuel { get; set; }
        public int FuelConsumption { get; set; }
        public int Mileage { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public enum TransmissionType
    {
        Manual,
        Automatic,
        SemiAutomatic
    }

    public enum Drivetrain
    {
        FWD,
        RWD,
        AWD,
        _4WD
    }

    public enum FuelType
    {
        Gasoline,
        Diesel,
        Hybrid,
        Electric,
        LPG,
    }
}
