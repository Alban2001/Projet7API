using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Domain;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("/Users")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Users()
        {
            var users = await _userRepository.FindAll();
            return Ok(users);
        }

        [HttpPost]
        [Route("/User")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var user1 = new User { UserName = user.UserName, Email = user.Email, Fullname = user.Fullname, EmailConfirmed = true };
            var result = await _userManager.CreateAsync(user1, user.Password);
            await _userManager.AddToRoleAsync(user1, "USER");

            return Created(string.Empty, user);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Utilisateur(string id)
        {
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Vérifie que c’est bien le même
            if (currentUserId == null || currentUserId != id)
                return Unauthorized("Vous n'êtes pas autorisé à accéder à cet utilisateur !");

            User user = await _userRepository.FindById(id);

            if (user == null)
                return NotFound("Utilisateur introuvable");

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(string id, [FromBody] User userUpdate)
        {
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Vérifie que c’est bien le même
            if (currentUserId == null || currentUserId != id)
                return Unauthorized("Vous n'êtes pas autorisé à accéder à cet utilisateur !");

            User user = await _userRepository.FindById(id);

            if (user == null)
                return NotFound("Utilisateur introuvable");

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            user.Fullname = userUpdate.Fullname;
            user.Email = userUpdate.Email;
            user.UserName = userUpdate.UserName;

            await _userManager.UpdateAsync(user);

            if (!string.IsNullOrEmpty(userUpdate.OldPassword) && !string.IsNullOrEmpty(userUpdate.Password))
            { 
                var passwordResult = await _userManager.ChangePasswordAsync(user, userUpdate.OldPassword, userUpdate.Password);

                if (!passwordResult.Succeeded)
                    return BadRequest(passwordResult.Errors);
            }

            return Created(string.Empty, user);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Vérifie que c’est bien le même
            if (currentUserId == null || currentUserId != id)
                return Unauthorized("Vous n'êtes pas autorisé à accéder à cet utilisateur !");

            User user = await _userRepository.FindById(id);

            if (user == null)
                return NotFound("Utilisateur introuvable");

            await _userManager.DeleteAsync(user);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}/articles")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
        {
            return Ok();
        }
    }
}