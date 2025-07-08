using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskAuthApi.Models;
using TaskAuthApi.Models.Dtos;
using TaskAuthApi.Services;

namespace TaskAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var user = new AppUser { UserName = dto.UserName, Email = dto.EmailAddress };
            var result = await _userManager.CreateAsync(user,dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok("user registered succesfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return Unauthorized("Invalid password");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }

    }
}
