using Gateway.WebApi.Data.Entieties;
using Gateway.WebApi.Dtos.User;
using Gateway.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Data;
using User.Microservice.Data.Migrations;
using User.Microservice.Models;
using static User.Microservice.Areas.Identity.Pages.Account.ExternalLoginModel;

namespace Gateway.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PetTrackerContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public List<AuthenticationScheme> ExternalLogins { get; private set; }

        public UserController(PetTrackerContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        //[HttpPost("register")]
        //public ActionResult<AspNetUsers> Register(UserCreateDto request)
        //{

        //    var user = new AspNetUsers
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Email = request.Email,
        //        PasswordHash = AesCrypto.EncryptString(request.PasswordHash),
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        RoleId = request.RoleId
        //    };

        //    _context.AspNetUsers.Add(user);
        //    _context.SaveChanges();

        //    return Ok(user);

        //}
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModels model)
        {
                        
            if (ModelState.IsValid)
            {
              
                var user = new ApplicationUser {
                    UserName = model.Email,
                    Email = model.Email,
                    Password=model.Password,
                    FirstName = model.FirstName,
                    LastName=model.LastName,
                    RoleId=model.Role                                       
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(ModelState);
        }

        //[HttpPost("login")]
        //public ActionResult<AspNetUsers> Login(UserReadDto request)
        //{
        //    var user = _context.AspNetUsers.FirstOrDefault(u => u.Email == request.Email);
        //    if (user == null)
        //    {
        //        return BadRequest("User not found.");
        //    }
        //    string encryptedPassword = AesCrypto.EncryptString(request.PasswordHash);

        //    if (user.PasswordHash != encryptedPassword)
        //    {
        //        return BadRequest("Wrong password.");
        //    }

        //    return Ok("User u bo login");
        //}
        //[HttpPost("login")]
        //public async Task<IActionResult> Login(InputModel model)
        //{
        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

        //        if (result.Succeeded)
        //        {
        //            return Ok();
        //        }

        //        return Unauthorized();
        //    }

        //    return BadRequest(ModelState);
        //}
        [HttpGet]
        public async Task<ActionResult<List<AspNetUsers>>> Get()
        {
            return Ok(await _context.AspNetUsers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AspNetUsers>> Get(int id)
        {
            var user = await _context.AspNetUsers.FindAsync(id);
            if (user == null)
                return BadRequest("Hero not found.");
            return Ok(user);
        }

        //[HttpPut]
        //public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        //{
        //    var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
        //    if (dbHero == null)
        //        return BadRequest("Hero not found.");

        //    dbHero.Name = request.Name;
        //    dbHero.FirstName = request.FirstName;
        //    dbHero.LastName = request.LastName;
        //    dbHero.Place = request.Place;

        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.SuperHeroes.ToListAsync());
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        //{
        //    var dbHero = await _context.SuperHeroes.FindAsync(id);
        //    if (dbHero == null)
        //        return BadRequest("Hero not found.");

        //    _context.SuperHeroes.Remove(dbHero);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.SuperHeroes.ToListAsync());
        //}

    }
}