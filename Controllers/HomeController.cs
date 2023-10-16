using InsurenceWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InsurenceWebApp.Data;



namespace InsurenceWebApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
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
            if(User.Identity.Name != null) 
            {
                var uzivatel = _context.MyUser.Single(item => item.Email == User.Identity.Name);
                if (uzivatel.Name.Length <= 1)
                {
                    return RedirectToAction("Edit","MyUser",new { uzivatel.Id });
                }
                else
                {
                    return View();
                }
            }

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