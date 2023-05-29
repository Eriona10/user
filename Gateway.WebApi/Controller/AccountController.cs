//using Gateway.WebApi.Data.Entieties;
//using Gateway.WebApi.Repository.User;
//using Microsoft.AspNetCore.Mvc;

//namespace Gateway.WebApi.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController] 
//    public class AccountController : ControllerBase
//    {
//        private  IUserRepository _userRepository;

//        public AccountController(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }
//        [HttpPost("signup")]
//        public async Task<IActionResult> SignUp([FromBody] AspNetUsers user)
//        {
//            var result = await _userRepository.SignUpAsync(user);

//            if (result.Succeeded)
//            {
//                return Ok(result.Succeeded);
//            }

//            return Ok("sedi");
//        }

//    }
//}
