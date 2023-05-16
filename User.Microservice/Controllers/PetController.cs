using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.Data;
using User.Microservice.Models;
using User.Microservice.Data.Entieties;

namespace User.Microservice.Controllers
{
    [Authorize(Roles ="user")]
    public class PetController : BaseController
    {
            
        public PetController(ApplicationDbContext context, PetTrackerContext db,UserManager<ApplicationUser> userManager) : base(context,db, userManager)
        {
        }

        public IActionResult Index()
        {
                  

            return View();
        }
    }
}
