using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using User.Microservice.Data;
using User.Microservice.Data.Entieties;
using User.Microservice.Helpers.Security;
using User.Microservice.Helpers;
using User.Microservice.Models;
using User.Microservice.Repository.General;
using User.Microservice.ViewModel.Authorization;

namespace User.Microservice.Controllers
{
    public class AuthorizationController : BaseController
    {
        public RoleManager<IdentityRole> _roleManager;
       // public RoleManager<ApplicationRole> _roleManager;
       //rivate IFunctionRepository _functionRepository;
        public AuthorizationController(ApplicationDbContext context, PetTrackerContext db,
             RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager) : base(context,db, userManager)
        {
            _roleManager = roleManager;
           //functionRepository = functionRepository;
        }

        public IActionResult Index()
        {

            var roles = _roleManager.Roles.ToList();

            return View(roles);
        }

     [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
      /*  //metoda per me i shfaq menut
        //si parameter vjen roli i zgjedhur ne view index
        [HttpPost]
        public async Task<IActionResult> _Search(AuthorizationCreateViewModel model)
        {
            List<ListOfMenusAccess> lista = await _functionRepository.ListOfMenusAuthorized(model.Role);


            return PartialView(lista);
        }

        //Metoda perdoret per insertimin e qasjeve ne db
        //Nese ka qasje dhe access = false, i fshin qasjet
        //Nese nuk ka qasje dhe access = true i inserton
        [HttpPost]
        public async Task<IActionResult> ChangeAccess(string Role, string mide, string side, bool access)
        {
            if (string.IsNullOrEmpty(Role))
            {
                return Json(new ViewModel.ErrorViewModel
                {
                    ErrorNumber = ErrorStatus.Error,
                    ErrorDescription = "Te dhenat jo valide"
                });
            }

            //Dekriptimin e id-ve te menus dhe submenus
            int menuId = AesCrypto.Decrypt<int>(mide);
            int submenuId = AesCrypto.Decrypt<int>(side);

            Menu menu = null;
            Submenu subMenu = null;
            string claim = "", claimValue = "";

            //nese submenu ekziston
            if (submenuId != 0)
            {
                //gjejm submenu
                subMenu = await _db.Submenu.FindAsync(submenuId);

                //marrim claims te submenus
                claim = subMenu.Claim.Split(':')[0];
                claimValue = subMenu.Claim.Split(':')[1];
            }
            else
            {
                //gjejm menu
                menu = await _db.Menu.FindAsync(menuId);

                //marrim claims te menus
                claim = menu.Claim.Split(':')[0];
                claimValue = menu.Claim.Split(':')[1];
            }

            //gjejm rolin ne baze te parametrit Role
            ApplicationRole role = await _roleManager.FindByIdAsync(Role);

            //bejme check ne db tek tabela AspNetRoleClaims
            //nese ky rol i permban keto claims
            var hasClaims = _db.AspNetRoleClaims.Where(q => q.RoleId == role.Id &&
                                                       q.ClaimType == claim &&
                                                       q.ClaimValue == claimValue).Any();
            //Nese parametri access vlera e te cilit 
            //vjen nga view
            //Nese true dhe role nuk ka claims
            //I ben insert ne tabelen AspNetRoleClaims
            if (access && !hasClaims)
            {
                await _roleManager.AddClaimAsync(role, new Claim(claim, claimValue));
            }
            else // e kunderta, i fshin claims nga tabela AspNetRoleClaims per rolin e zgjedhur
            {
                await _roleManager.RemoveClaimAsync(role, new Claim(claim, claimValue));
            }

            ViewModel.ErrorViewModel error = new ViewModel.ErrorViewModel
            {
                Title = "Sukses",
                ErrorNumber = ErrorStatus.Success,
                ErrorDescription = "Te dhenat u ruajten me sukses"
            };

            return Json(error);
        }*/
    }
}