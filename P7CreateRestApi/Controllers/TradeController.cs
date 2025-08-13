using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TradeController : ControllerBase
    {
        private TradeRepository _tradeRepository;

        public TradeController(TradeRepository tradeRepository)
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

            return Ok(trades);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Trade(int id)
        {
            Trade trade = await _tradeRepository.FindById(id);

            if (trade == null)
                throw new ArgumentException("Invalid trade Id:" + id);

            return Ok(trade);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Trade trade)
        {
            if (trade.TradeId != id)
                throw new ArgumentException("Invalid trade Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _tradeRepository.Update(trade);

            var trades = await _tradeRepository.FindAll();

            return Ok(trades);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Trade trade = await _tradeRepository.FindById(id);

            if (trade == null)
                throw new ArgumentException("Invalid trade Id:" + id);

            _tradeRepository.Delete(trade);

            var trades = await _tradeRepository.FindAll();

            return Ok(trades);
        }
    }
}