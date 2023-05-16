/*using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using User.Microservice.Data;
using User.Microservice.Data.Entieties;
using User.Microservice.Models;
using User.Microservice.ViewModel;
using User.Microservice.ViewModel.Submenu;

namespace User.Microservice.Controllers
{
    public class SubmenuController :BaseController
    {
       
        public SubmenuController(ApplicationDbContext context,
            PetTrackerContext db, UserManager<ApplicationUser> userManager) : base(context, db, userManager)
        {

        }
    

        public IActionResult Index()
        {
            var submenu = _db.Submenu.Select(x => new SubmenuViewModel {Id=x.SubmenuId, MId = x.MenuId, Name = x.Name, Area = x.Area, Action = x.Action, Controller = x.Controller}).ToList();

            List<SubmenuViewModel> model = new List<SubmenuViewModel>();

            return View(submenu);
        }
        [HttpGet]
        public IActionResult _Create(int id)
        {
            var menu = _db.Menu.Find(id);

            SubmenuCreateViewModel model = new SubmenuCreateViewModel()
            {
                MId = menu.MenuId,
                Menu = menu.Name,
                IsActive = true
            };

            var submenus = _db.Submenu.Where(q => q.MenuId == menu.MenuId).Select(q => new { q.SubmenuId, q.Name}).ToList();

            ViewBag.ParentId = new SelectList(submenus, "SubmenuId", "NameSq");

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult _Create(SubmenuCreateViewModel model)
        {
            ViewModel.ErrorViewModel error = new ViewModel.ErrorViewModel { ErrorNumber = Helpers.ErrorStatus.Success, ErrorDescription = "Menu eshte regjistruar me sukses", Title = "Sukses" };

            if (!ModelState.IsValid)
            {
                error = new ViewModel.ErrorViewModel { ErrorNumber = Helpers.ErrorStatus.Warning, ErrorDescription = "Plotesoni te dhenat obligative", Title = "Lajmerim" };
                return Json(error);
            }

            Submenu subMenu = new Submenu
            {
                MenuId = model.MId,
                Action = model.Action,
                Controller = model.Controller,
                Area = model.Area,
                Claim = model.Policy,
                ClaimType = model.Policy != null ? model.Policy.Split(':')[0] : null,
                Icon = model.Icon,
                IsActive = true,
                Name = model.Name,
                OrdinalNumber = model.OrdinalNumber,
                StaysOpenFor = model.StaysOpenFor,
                ParentSubId = model.ParentID,
                InsertedDate = DateTime.Now,
                InsertedFrom = "a9b31e68-99ab-4b6d-96ea-8bc396d6de21",

            };

            _db.Submenu.Add(subMenu);

            _db.SaveChanges();

            return Json(error);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ;
            //int did = AesCrypto.Decrypt<int>(ide);
            var submenu = _db.Submenu.Find(id);


            if (submenu == null)
            {
                return NotFound();
            }

            SubmenuEditViewModel editViewModel = new SubmenuEditViewModel
            {
                Id = submenu.SubmenuId,
                MId = submenu.MenuId,
                Action = submenu.Action,
                Controller = submenu.Controller,
                Area = submenu.Area,
                Policy = submenu.Claim,
                Icon = submenu.Icon,
                IsActive = true,
                Name = submenu.Name,
                OrdinalNumber = submenu.OrdinalNumber,
                StaysOpenFor = submenu.StaysOpenFor,
                ParentID =submenu.ParentSubId

            };
            return PartialView(editViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(SubmenuEditViewModel model)
        {


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Plotesoni fushat obligative");
                return View(model);
            }
            var submenu = _db.Submenu.Find(model.Id);
            if (submenu == null)
            {
                ModelState.AddModelError("", "Komuna nuk ekziston");
                return View(model);

            }
            submenu.Action = model.Action;
            submenu.Controller = model.Controller;
            submenu.Area = model.Area;
            submenu.Claim = model.Policy;
            submenu.Icon = model.Icon;
            submenu.Name = model.Name;
            submenu.OrdinalNumber = model.OrdinalNumber;
            submenu.StaysOpenFor = model.StaysOpenFor;
            submenu.ParentSubId = model.ParentID;

            //var result= await

            _db.Update(submenu);

            _db.SaveChanges();

            return RedirectToAction("Index", "Reminder");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {

            if (Id == null)
            {
                return BadRequest();
            }


            var submenu = _db.Submenu.Find(Id);
            if (submenu != null)
            {
                var result = _db.Submenu.Remove(submenu);

                await _db.SaveChangesAsync();

            }

            return Json("success");

        }
    }
}*/