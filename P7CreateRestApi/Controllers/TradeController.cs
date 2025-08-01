using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        // TODO: Inject Trade service
        private TradeRepository _tradeRepository;

        public TradeController(TradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        [HttpGet]
        [Route("/Trades")]
        public IActionResult Trades()
        {
            // TODO: find all Trade, add to model
            return Ok();
        }

        [HttpPost]
        [Route("/Trade")]
        public IActionResult Create([FromBody]Trade trade)
        {
            // TODO: check data valid and save to db, after saving return Trade list
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Trade(int id)
        {
            // TODO: get Trade by Id and to model then show to the form
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] Trade trade)
        {
            // TODO: check required fields, if valid call service to update Trade and return Trade list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Find Trade by Id and delete the Trade, return to Trade list
            return Ok();
        }
    }
}