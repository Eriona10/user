using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.Models;
using User.Microservice.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using User.Microservice.Data.Entieties;

namespace User.Microservice.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly PetTrackerContext _db;
        public readonly UserManager<ApplicationUser> _userManager;

        protected ApplicationUser user = new ApplicationUser();
                
        public BaseController(ApplicationDbContext context,
            PetTrackerContext db, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _db = db;
            _userManager = userManager;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            user = await _userManager.GetUserAsync(context.HttpContext.User);

           ViewData["User"] = new UserModel
            {
               Id = user.Id,
               FirstName = user.FirstName,
               LastName = user.LastName,
               Email = user.Email,        
               Username = user.UserName,
               PhoneNumber = user.PhoneNumber

           };

            await next();
        }
    }
}
