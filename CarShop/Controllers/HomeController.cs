using CarShop.Models;
using CarShop.Models.ModelData;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarData _db;

        public HomeController(ILogger<HomeController> logger, CarData db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.GetAllCars());
        }

        public IActionResult CarPage(int carId)
        {
            var car = _db.GetCar(carId);
            return View(car);
        }
    }
}