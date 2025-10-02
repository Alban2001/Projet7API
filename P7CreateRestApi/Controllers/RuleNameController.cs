using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7CreateRestApi.Repositories;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RuleNameController : ControllerBase
    {
        private IRuleNameRepository _ruleNameRepository;

        public RuleNameController(IRuleNameRepository ruleNameRepository)
        {
            _ruleNameRepository = ruleNameRepository;
        }

        [HttpGet]
        [Route("/RuleNames")]
        public async Task<IActionResult> RuleNames()
        {
            var ruleNames = await _ruleNameRepository.FindAll();
            return Ok(ruleNames);
        }

        [HttpPost]
        [Route("/RuleName")]
        public async Task<IActionResult> Create([FromBody]RuleName rulename)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _ruleNameRepository.Add(rulename);

            var rulenames = await _ruleNameRepository.FindAll();

            return Created(string.Empty, rulenames);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> RuleName(int id)
        {
            RuleName rulename = await _ruleNameRepository.FindById(id);

            if (rulename == null)
                throw new ArgumentException("Invalid rulename Id:" + id);

            return Ok(rulename);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RuleName rulename)
        {
            if (rulename.Id != id)
                throw new ArgumentException("Invalid rulename Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _ruleNameRepository.Update(rulename);

            var rulenames = await _ruleNameRepository.FindAll();

            return Created(string.Empty, rulenames);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            RuleName rulename = await _ruleNameRepository.FindById(id);

            if (rulename == null)
                throw new ArgumentException("Invalid rulename Id:" + id);

            _ruleNameRepository.Delete(rulename);

            return NoContent();
        }
    }
}