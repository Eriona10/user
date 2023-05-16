using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.Data;
using User.Microservice.Data.Entieties;
using User.Microservice.Models;

namespace User.Microservice.Controllers
{        [Authorize]
    public class UserController : BaseController
    {

        public UserController(ApplicationDbContext context,
            PetTrackerContext db, UserManager<ApplicationUser> userManager):base(context, db, userManager)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
