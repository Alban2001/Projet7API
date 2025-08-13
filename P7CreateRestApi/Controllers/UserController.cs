using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Domain;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
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
           
           _userRepository.Add(user);

            var users = await _userRepository.FindAll();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> User(int id)
        {
            User user = await _userRepository.FindById(id);
            
            if (user == null)
                throw new ArgumentException("Invalid user Id:" + id);

            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            if (user.Id != id)
                throw new ArgumentException("Invalid user Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userRepository.Update(user);

            var users = await _userRepository.FindAll();

            return Ok(users);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _userRepository.FindById(id);
            
            if (user == null)
                throw new ArgumentException("Invalid user Id:" + id);

            _userRepository.Delete(user);

            var users = await _userRepository.FindAll();

            return Ok(users);
        }

        [HttpGet]
        [Route("{id}/articles")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
        {
            return Ok();
        }
    }
}