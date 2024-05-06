using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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

        public IActionResult About()
        {
            ViewBag.Message = "this is a about page";
            return View();
        }

        public IActionResult Numbers()
        {
            ViewBag.Message = "Nums1...50";
            return View();
        }

        public IActionResult NumbersToN(int count)
        {
            ViewBag.Count = count;
            ViewBag.Message = "Nums1...50";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}