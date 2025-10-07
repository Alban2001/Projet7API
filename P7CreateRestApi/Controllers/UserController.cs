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
        public async Task<IActionResult> Create([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user1 = new User { UserName = user.UserName, Email = user.Email, Fullname = user.Fullname };
            var result = await _userManager.CreateAsync(user1, user.Password);
            await _userManager.AddToRoleAsync(user1, "USER");

            //_userRepository.Add(user1);

            var users = await _userRepository.FindAll();

            return Created(string.Empty, users);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> User(string id)
        {
            User user = await _userRepository.FindById(id);
            
            if (user == null)
                return NotFound("Utilisateur introuvable");

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(string id, [FromBody] User user)
        {
            if (user.Id != id)
                return NotFound("Utilisateur introuvable");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _userManager.UpdateAsync(user);

            var users = await _userRepository.FindAll();

            return Created(string.Empty, users);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
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