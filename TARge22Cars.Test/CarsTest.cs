using CarsAppTest;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARge22Cars.ApplicationService.Services;
using TARge22Cars.Core.Domain;
using TARge22Cars.Core.Dto;
using TARge22Cars.Core.ServiceInterface;

namespace TARge22Cars.CarsTest
{
    public class CarsTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            //Arrange
            CarDto car = new();
            {
                car.CarId = null;
                car.Make = "BMW";
                car.Model = "E46";
                car.Color = "gray";
                car.Year = DateTime.Now.Year - 25;
                car.Power = "110";
                car.Transmission = TransmissionType.Manual;
                car.Drivetrain = "RWD";
                car.Fuel = "Gasoline";
                car.FuelConsumption = 6;
                car.Mileage = 90000;
                car.CreatedAt = DateTime.Now;
                car.UpdatedAt = DateTime.Now;
            };

            //Act
            var result = await Svc<ICarsServices>().Create(car);

            //Assert
            Assert.NotNull(result);
        }



        [Fact]
        public async Task Should_UpdateCar_WhenUpdateData()
        {
            CarDto dto = MockCarData();
            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto update = MockUpdateCarData();
            var result = await Svc<ICarsServices>().Update(update);

            Assert.DoesNotMatch(result.Make, createCar.Make);
            Assert.NotEqual(result.UpdatedAt, createCar.UpdatedAt);
            Assert.NotEqual(result.Model, createCar.Model);
        }

        [Fact]
        public async Task Should_GetByCarId_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");
            Guid guid = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");

            await Svc<ICarsServices>().DetailsAsync(guid);

            Assert.Equal(databaseGuid, guid);
        }
        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarDto dto = MockCarData();
            var createRealestate = await Svc<ICarsServices>().Create(dto);

            CarDto nullUpdate = MockNullCar();
            var result = await Svc<ICarsServices>().Update(nullUpdate);

            var nullId = nullUpdate.CarId;

            Assert.True(dto.CarId == nullId);
        }
        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                CarId = null,
                Make = "Skoda",
                Model = "Superb",
                Color = "Blue",
                Year = DateTime.Now.Year - 25,
                Power = "132",
                Transmission = TransmissionType.Manual,
                Drivetrain = "FWD",
                Fuel = "Gasoline",
                FuelConsumption = 6,
                Mileage = 98000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return car;
        }

        private CarDto MockUpdateCarData()
        {
            CarDto car = new()
            {
                CarId = null,
                Make = "BMW",
                Model = "E46",
                Color = "gray",
                Year = DateTime.Now.Year - 25,
                Power = "110",
                Transmission = TransmissionType.Manual,
                Drivetrain = "RWD",
                Fuel = "Gasoline",
                FuelConsumption = 6,
                Mileage = 90000,
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddDays(+3),
            };

            return car;
        }
        private CarDto MockNullCar()
        {
            CarDto nullDto = new()
            {
                CarId = null,
                Make = "Audi",
                Model = "A4",
                Color = "blue",
                Year = DateTime.Now.Year - 20,
                Power = "150",
                Transmission = TransmissionType.Automatic,
                Drivetrain = "AWD",
                Fuel = "Diesel",
                FuelConsumption = 5,
                Mileage = 75000,
                CreatedAt = DateTime.Now.AddMonths(6),
                UpdatedAt = DateTime.Now.AddDays(+5),

            };

            return nullDto;
        }

    }
}
