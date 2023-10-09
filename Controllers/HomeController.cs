using InsurenceWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InsurenceWebApp.Controllers
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

        public IActionResult GDPR()
        {
            return View();
        }

        public IActionResult HlaseniSkody()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        public IActionResult PojisteniCestovni()
        {
            return View();
        }

        public IActionResult PojisteniMajetku()
        {
            return View();
        }

        public IActionResult PojisteniVozidel()
        {
            return View();
        }

        public IActionResult SjednatPojisteni()
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