using HomeHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeHub.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ILogger<RealEstateController> _logger;

        public RealEstateController(ILogger<RealEstateController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}