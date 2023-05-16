using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.Data;
using User.Microservice.Models;
using System.Diagnostics;
using User.Microservice.Data.Entieties;

namespace User.Microservice.Controllers
{ 
  
    public class HomeController : BaseController
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context,
         PetTrackerContext db,
         UserManager<ApplicationUser> userManager,ILogger<HomeController> logger) : base(context, db, userManager)
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