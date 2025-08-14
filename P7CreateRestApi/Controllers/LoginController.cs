using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Models;
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

        public LoginController(IAuthenticationService authenticationService, IConfiguration config) {
            _authenticationService = authenticationService;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            //TODO: implement the UserManager from Identity to validate User and return a security token.
            var user = _authenticationService.Authenticate(model.UserName, model.Password);

            if (user != null) {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.UserName)
                };
                var token = _authenticationService.GenerateToken(_config["Jwt:Key"], claims);

                return Ok(token);
            }

            return Unauthorized();
        }            
    }
}