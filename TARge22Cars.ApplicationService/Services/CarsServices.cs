
using Microsoft.EntityFrameworkCore;
using TARge22Cars.Core.Domain;
using TARge22Cars.Core.Dto;
using TARge22Cars.Core.ServiceInterface;
using TARge22Cars.Data;

namespace TARge22Cars.ApplicationService.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARge22CarsContext _context;

        public CarsServices
            (
            TARge22CarsContext context
            )
        {
            _context = context;
        }


        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.CarId = Guid.NewGuid();
            car.Make = dto.Make;
            car.Model = dto.Model;
            car.Color = dto.Color;
            car.Year = dto.Year;
            car.Transmission = dto.Transmission;
            car.Power = dto.Power;
            car.Fuel = dto.Fuel;
            car.FuelConsumption = dto.FuelConsumption;
            car.Mileage = dto.Mileage;
            car.Drivetrain = dto.Drivetrain;

            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car domain = new();

            domain.CarId = Guid.NewGuid();
            domain.Make = dto.Make;
            domain.Model = dto.Model;
            domain.Color = dto.Color;
            domain.Year = dto.Year;
            domain.Transmission = dto.Transmission;
            domain.Power = dto.Power;
            domain.Fuel = dto.Fuel;
            domain.FuelConsumption = dto.FuelConsumption;
            domain.Mileage = dto.Mileage;
            domain.Drivetrain = dto.Drivetrain;
            domain.CreatedAt = DateTime.Now;
            domain.UpdatedAt = DateTime.Now;

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;

        }

        public async Task<Car> DetailsAsync (Guid id)
        {
            var result = await _context.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            return result;
        }

        public async Task<Car> Delete (Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x=> x.CarId == id);

            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
    }
}
