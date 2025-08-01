using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RuleNameController : ControllerBase
    {
        // TODO: Inject RuleName service
        private RuleNameRepository _ruleNameRepository;

        public RuleNameController(RuleNameRepository ruleNameRepository)
        {
            _ruleNameRepository = ruleNameRepository;
        }

        [HttpGet]
        [Route("/RuleNames")]
        public IActionResult RuleNames()
        {
            // TODO: find all RuleName, add to model
            return Ok();
        }

        [HttpPost]
        [Route("/RuleName")]
        public IActionResult Create([FromBody]RuleName trade)
        {
            // TODO: check data valid and save to db, after saving return RuleName list
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Trade(int id)
        {
            // TODO: get RuleName by Id and to model then show to the form
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] RuleName rating)
        {
            // TODO: check required fields, if valid call service to update RuleName and return RuleName list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Find RuleName by Id and delete the RuleName, return to Rule list
            return Ok();
        }
    }
}