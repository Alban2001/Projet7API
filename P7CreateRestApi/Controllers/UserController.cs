using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Users()
        {
            return Ok();
        }

        //[HttpGet]
        //[Route("add")]
        //public IActionResult AddUser([FromBody]User user)
        //{
        //    return Ok();
        //}

        [HttpPost]
        [Route("/Users")]
        public IActionResult Create([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           
           _userRepository.Add(user);

            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult User(int id)
        {
            User user = _userRepository.FindById(id);
            
            if (user == null)
                throw new ArgumentException("Invalid user Id:" + id);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            // TODO: check required fields, if valid call service to update Trade and return Trade list

            if (user.Id != id)
                throw new ArgumentException("Invalid user Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userRepository.Update(user);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _userRepository.FindById(id);
            
            if (user == null)
                throw new ArgumentException("Invalid user Id:" + id);

            _userRepository.Delete(user);

            return Ok();
        }

        [HttpGet]
        [Route("{id}/articles")]
        public async Task<ActionResult<List<User>>> GetAllUserArticles()
        {
            return Ok();
        }
    }
}