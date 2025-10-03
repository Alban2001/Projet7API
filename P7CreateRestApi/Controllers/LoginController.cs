using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Models;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;
using System.Security.Claims;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _config;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public LoginController(IAuthenticationService authenticationService, IConfiguration config, SignInManager<User> signInManager, UserManager<User> userManager, IUserRepository userRepository) {
            _authenticationService = authenticationService;
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = _userRepository.FindByUserName(model.UserName);
            if (user == null) return Unauthorized("Utilisateur introuvable");

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) return Unauthorized("Mot de passe invalide");

            // Récupérer les rôles
            var roles = await _userManager.GetRolesAsync(user);

            if (roles != null && roles.Count > 0) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.UserName)
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var token = _authenticationService.GenerateToken(_config["Jwt:Key"], claims);

                return Ok(token);
            }

            return Unauthorized();
        }            
    }
}