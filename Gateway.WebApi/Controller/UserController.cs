//using AutoMapper;
//using Gateway.WebApi.Data.Entieties;

//using Microsoft.AspNetCore.Mvc;

//namespace Gateway.WebApi.Controller
//{
//    //[ApiController]
//    //[Route("[controller]")]
//    [Route("api/auth")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        //private readonly IMapper _mapper;

//        //private IUserRepository _userRepository;

//        //public UserController(IMapper mapper, IUserRepository userRepository)
//        //{
//        //    _mapper = mapper;
//        //    _userRepository= userRepository;

//        //}

//        //[HttpGet]
//        //public IActionResult GetUser()
//        //{
//        //    var result = _userRepository.GetAllUser();

//        //    return Ok(result);
//        //}
//    }   }
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using User.Microservice.Areas.Identity.Pages.Account;
// ...

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public UserController(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("login")]

    public async Task<IActionResult> Login(LoginModel model)
    {
        // Validate login data
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Find the user by email
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return BadRequest("Invalid email or password");
        }

        // Check if the provided password is correct
        var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
        if (!passwordValid)
        {
            return BadRequest("Invalid email or password");
        }

        // Create claims for the user
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            // Add additional claims as needed
        };
        // Generate the JWT token
        var token = GenerateJwtToken(claims);

        // Return the token
        return Ok(new { token });
    }

    private string GenerateJwtToken(Claim[] claims)
    {
        var secretKey = _configuration["Jwt:SecretKey"];
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var expiration = int.Parse(_configuration["Jwt:Expiration"]);

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiration),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("register")]
 
    public async Task<IActionResult> Register(RegisterModel model)
    {
        // Validate registration data
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Check if user with the same email already exists
        var userExists = await _userManager.FindByEmailAsync(model.Email);
        if (userExists != null)
        {
            return BadRequest("User with this email already exists");
        }

        // Create a new IdentityUser object with the user's information
        var user = new IdentityUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        // Check if the user was successfully created
        if (result.Succeeded)
        {
            return Ok("Registration successful");
        }
        else
        {
            // Return the error message(s)
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return BadRequest(ModelState);
        }
    }

}

