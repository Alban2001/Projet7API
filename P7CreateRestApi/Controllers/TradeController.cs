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
    public class TradeController : ControllerBase
    {
        private ITradeRepository _tradeRepository;

        public TradeController(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        [HttpGet]
        [Route("/Trades")]
        public async Task<IActionResult> Trades()
        {
            var trades = await _tradeRepository.FindAll();
            return Ok(trades);
        }

        [HttpPost]
        [Route("/Trade")]
        public async Task<IActionResult> Create([FromBody]Trade trade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _tradeRepository.Add(trade);

            var trades = await _tradeRepository.FindAll();

            return Created(string.Empty, trades);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Trade(int id)
        {
            Trade trade = await _tradeRepository.FindById(id);

            if (trade == null)
                return NotFound("Trade introuvable");

            return Ok(trade);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Trade trade)
        {
            if (trade.TradeId != id)
                return NotFound("Trade introuvable");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _tradeRepository.Update(trade);

            var trades = await _tradeRepository.FindAll();

            return Created(string.Empty, trades);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Trade trade = await _tradeRepository.FindById(id);

            if (trade == null)
                return NotFound("Trade introuvable");

            _tradeRepository.Delete(trade);

            return NoContent();
        }
    }
}