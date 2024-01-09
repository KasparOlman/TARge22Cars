using Microsoft.AspNetCore.Mvc;
using TARge22Cars.Data;
using TARge22Cars.Models.Cars;

namespace TARge22Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARge22CarsContext _context;
        public CarsController(TARge22CarsContext context)
        {
            _context = context;
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
            return View();
        }
    }
}
