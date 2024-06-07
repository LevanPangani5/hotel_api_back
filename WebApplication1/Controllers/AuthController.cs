using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTO;
using WebApplication1.Data.Model;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AuthController( UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AuthController> logger, IMapper mapper, IAuthManager authManager)
        {
     
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserLoginDto user)
        {
            _logger.LogInformation($"registration Atempt for {user.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var data = _mapper.Map<User>(user);
                data.UserName = user.Email;
                var result=  await _userManager.CreateAsync(data,user.Password);
                if (!result.Succeeded) 
                { 
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState); 
                }
                await _userManager.AddToRoleAsync(data, "User");

                return Accepted();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(Register)}",statusCode:500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            _logger.LogInformation($"login Atempt for {user.Email}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               if(!await _authManager.ValidateUser(user))
                {
                    return Unauthorized();
                }
               
                return Accepted(new { Token = await _authManager.CreateToken() });


            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"something when wrong in the {nameof(Register)}");
                return Problem($"something when wrong in the {nameof(Register)}", statusCode: 500);
            }
        }

    }
}
