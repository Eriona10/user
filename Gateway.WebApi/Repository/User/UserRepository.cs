//using Azure.Core;
//using Gateway.WebApi.Data.Entieties;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.EntityFrameworkCore;
//using System.Security.Policy;
//using System.Text.Encodings.Web;
//using System.Text;
//using User.Microservice.Models;
//using User.Microservice.Areas.Identity.Pages.Account;
//using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.ExternalLoginModel;
//using System.Data;

//namespace Gateway.WebApi.Repository.User
//{
//    public class UserRepository : IUserRepository
//    {
//        public PetTrackerContext _context;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly IConfiguration _configuration;



//        public UserRepository(PetTrackerContext context,UserManager<ApplicationUser> userManager,
//            SignInManager<ApplicationUser> signInManager,
//            IConfiguration configuration)
//        {
//            _context = context;
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _configuration = configuration;

//        } 
//        public async Task<IdentityResult> SignUpAsync(AspNetUsers user)
//        {
          
//            var users = new ApplicationUser()
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                UserName = user.Email
//            };

//            return await _userManager.CreateAsync(users, user.PasswordHash);
//        }

//        public Task<string> LoginAsync(AspNetUsers user)
//        {
//            throw new NotImplementedException();
//        }
//        public async Task SaveChanges()
//        {
//            await _context.SaveChangesAsync();
//        }

//        //public async Task CreateUser(AspNetUsers user)
//        //{
//        //    if (user == null)
//        //    {
//        //        throw new ArgumentNullException(nameof(user));
//        //    }
//        //    //insertimi ne databaze me EFCore

//        //    await _context.AspNetUsers.AddAsync(user);
//        //}

//        //public Task DeleteUser(AspNetUsers user)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public async Task<IEnumerable<AspNetUsers>> GetAllUser()
//        //{
//        //    var users = await _context.AspNetUsers.ToListAsync();

//        //    return users;
//        //}

//        //public Task<AspNetUsers> GetUserById(int id)
//        //{
//        //    throw new NotImplementedException();
//        //}

       

      
//    }
//}
