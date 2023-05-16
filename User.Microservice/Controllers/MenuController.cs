/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Microservice.Data;
using User.Microservice.Data.Entieties;
using User.Microservice.Helpers.Security;
using User.Microservice.Models;
using User.Microservice.ViewModel;
using User.Microservice.ViewModel.Menu;

namespace User.Microservice.Controllers
{
   // [Authorize(Policy = "ro:1")]
    public class MenuController : BaseController
    {
        public MenuController(ApplicationDbContext context,
            PetTrackerContext db, UserManager<ApplicationUser> userManager) : base(context,db,userManager)
        {
           
        }

        public IActionResult Index()
        {
            var menus = _db.Menu.Select(q => new MenuViewModel
            {
                Id = q.MenuId,
                Name = q.Name,
                Area = q.Area,
                Action = q.Action,
                Controller = q.Controller,
                Icon = q.Icon,
                HasSubMenu = q.HasSubMenu
            }).ToList();

            return View(menus);
        }

        [HttpGet]
        public IActionResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Create(MenuCreateViewModel model)
        {
            ViewModel.ErrorViewModel error = new ViewModel.ErrorViewModel { ErrorNumber = Helpers.ErrorStatus.Success, ErrorDescription = "Menu eshte regjistruar me sukses", Title = "Sukses" };

            if (!ModelState.IsValid)
            {
                error = new ViewModel.ErrorViewModel { ErrorNumber = Helpers.ErrorStatus.Warning, ErrorDescription = "Plotesoni te dhenat obligative", Title = "Lajmerim" };
                return Json(error);
            }

            Menu add = new Menu()
            {
                Name = model.Name,
                Area = model.Area,
                Action = model.Action,
                Controller = model.Controller,
                HasSubMenu = model.HasSubMenu,
                IsActive = true,
               InsertedFrom = user.Id,
                InsertedDate = DateTime.Now,
                OrdinalNumber = model.OrdinalNumber,
                StaysOpenFor = model.StaysOpenFor,
                Icon = model.Icon,
                Claim = model.Policy,
                ClaimType = model.Policy != null ? model.Policy.Split(':')[0] : null,
            };


            _db.Menu.Add(add);
            _db.SaveChanges();

            return Json(error);
        }

        [HttpGet]
        public IActionResult _Edit(string? ide)
        {

            if (ide == null)
            {
                return BadRequest();
            }

            int did = AesCrypto.Decrypt<int>(ide);

            var menu = _db.Menu.Find(did);

            if (menu == null)
            {
                return NotFound();
            }

            MenuEditViewModel editViewModel = new MenuEditViewModel
            {
                Id = did,
                Action = menu.Action,
                Controller = menu.Controller,
                HasSubMenu = (bool)menu.HasSubMenu,
                Area = menu.Area,
                Icon = menu.Icon,
                Name = menu.Name,
                OrdinalNumber = menu.OrdinalNumber,
                Policy = menu.Claim,
                StaysOpenFor = menu.StaysOpenFor
            };

            return PartialView(editViewModel);
        }

        [HttpPost]
        public IActionResult _Edit(MenuEditViewModel model)
        {

            ViewModel.ErrorViewModel error = new ViewModel.ErrorViewModel { ErrorNumber = Helpers.ErrorStatus.Success, ErrorDescription = "Menu eshte modifikuar me sukses", Title = "Sukses" };

            if (!ModelState.IsValid)
            {
                error = new ViewModel.ErrorViewModel { ErrorNumber = Helpers.ErrorStatus.Warning, ErrorDescription = "Plotesoni te dhenat obligative", Title = "Lajmerim" };
                return Json(error);
            }

            var menu = _db.Menu.Find(model.Id);

            if (menu == null)
            {
                return NotFound();
            }

            menu.Name = model.Name;
            menu.Action = model.Action;
            menu.Controller = model.Controller;
            menu.Icon = model.Icon;
            menu.Area = model.Area;
            menu.Claim = model.Policy;
            menu.ClaimType = model.Policy != null ? model.Policy.Split(':')[0] : null;
            menu.UpdatedDate = DateTime.Now;
            menu.UpdatedFrom = user.Id;
            menu.HasSubMenu = model.HasSubMenu;
            menu.OrdinalNumber = model.OrdinalNumber;
            menu.StaysOpenFor = model.StaysOpenFor;

            _db.Update(menu);

            _db.SaveChanges();

            return Json(error);
        }
    }
}
*/