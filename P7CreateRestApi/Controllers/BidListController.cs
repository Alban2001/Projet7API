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
    public class BidListController : ControllerBase
    {
        private IBidListRepository _bidListRepository;

        public BidListController(IBidListRepository bidListRepository)
        {
            _bidListRepository = bidListRepository;
        }

        [HttpGet]
        [Route("/BidLists")]
        public async Task<IActionResult> BidLists()
        {
            var bidLists = await _bidListRepository.FindAll();

            return Ok(bidLists);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> BidList(int id)
        {
            BidList bidList = await _bidListRepository.FindById(id);

            if (bidList == null)
                return NotFound("BidList introuvable");

            return Ok(bidList);
        }

        [HttpPost]
        [Route("/BidList")]
        public async Task<IActionResult> Create([FromBody] BidList bidList)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _bidListRepository.Add(bidList);

            return Created(string.Empty, bidList);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BidList bidList)
        {
            BidList verifBidList = await _bidListRepository.FindById(id);

            if (verifBidList == null)
                return NotFound("BidList introuvable");

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _bidListRepository.Update(bidList);

            return Created(string.Empty, bidList);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            BidList bidList = await _bidListRepository.FindById(id);

            if (bidList == null)
                return NotFound("BidList introuvable");

            _bidListRepository.Delete(bidList);

            return NoContent();
        }
    }
}