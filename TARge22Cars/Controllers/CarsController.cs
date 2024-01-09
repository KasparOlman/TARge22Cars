using Microsoft.AspNetCore.Mvc;

namespace TARge22Cars.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
