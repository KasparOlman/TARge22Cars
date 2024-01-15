using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using TARge22Cars.Core.Dto;
using TARge22Cars.Core.ServiceInterface;
using TARge22Cars.Data;
using TARge22Cars.Models.Cars;

namespace TARge22Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge22CarsContext _context;
        private readonly ICarsServices _carsServices;
        public CarsController
            (
            
            TARge22CarsContext context,
            ICarsServices carsServices
            )
        {
            _context = context;
            _carsServices = carsServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarsIndexViewModel
                {
                    CarId = x.CarId,
                    Make = x.Make,
                    Model = x.Model,
                    Mileage = x.Mileage,
                    Fuel = x.Fuel,
                    Transmission = x.Transmission,
                    Drivetrain = x.Drivetrain

                });
            return View(result);

        }
        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateViewModel result = new();
            return View("CreateUpdate",result);
        }

        [HttpPost]
        public async Task <IActionResult> Create (CarsCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                CarId = vm.CarId,
                Make = vm.Make,
                Model = vm.Model,
                Color = vm.Color,
                Year = vm.Year,
                Power = vm.Power,
                Transmission = vm.Transmission,
                Drivetrain = vm.Drivetrain,
                Fuel = vm.Fuel,
                FuelConsumption = vm.FuelConsumption,
                Mileage = vm.Mileage,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarsDetailsViewModel();
            vm.CarId = car.CarId;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.Power = car.Power;
            vm.Transmission = car.Transmission;
            vm.Drivetrain = car.Drivetrain;
            vm.Fuel = car.Fuel;
            vm.FuelConsumption = car.FuelConsumption;
            vm.Mileage = car.Mileage;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update (Guid id)
        {
            var car = await _carsServices.DetailsAsync (id);

            if (car == null)
            {

                return NotFound();
            }
            var vm = new CarsCreateUpdateViewModel();
            vm.CarId = car.CarId;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Color = car.Color;
            vm.Year = car.Year;
            vm.Power = car.Power;
            vm.Transmission = car.Transmission;
            vm.Drivetrain = car.Drivetrain;
            vm.Fuel = car.Fuel;
            vm.FuelConsumption = car.FuelConsumption;
            vm.Mileage = car.Mileage;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarsCreateUpdateViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest();
            }
            var dto = new CarDto()
            {
                CarId = vm.CarId,
                Make = vm.Make,
                Model = vm.Model,
                Color = vm.Color,
                Year = vm.Year,
                Power = vm.Power,
                Transmission = vm.Transmission,
                Drivetrain = vm.Drivetrain,
                Fuel = vm.Fuel,
                FuelConsumption = vm.FuelConsumption,
                Mileage = vm.Mileage,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,

            };
            var result = await _carsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index),vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var vm = new CarsDeleteViewModel();

            vm.CarId = car.CarId;
            vm.Make = car.Make;
            vm.Model = car.Model;
            vm.Mileage = car.Mileage;
            vm.Fuel = car.Fuel;
            vm.Transmission = car.Transmission;
            vm.Power = car.Power;
            vm.Drivetrain = car.Drivetrain;
            vm.Color = car.Color;
            vm.FuelConsumption = car.FuelConsumption;
            vm.Year = car.Year;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
