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
        public async Task<IActionResult> BidListsAsync()
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
                throw new ArgumentException("Invalid bidList Id:" + id);

            return Ok(bidList);
        }

        [HttpPost]
        [Route("/BidList")]
        public async Task<IActionResult> Create([FromBody] BidList bidList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _bidListRepository.Add(bidList);

            var bidLists = await _bidListRepository.FindAll();

            return Created(string.Empty, bidLists);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BidList bidList)
        {
            if (bidList.BidListId != id)
                throw new ArgumentException("Invalid bidList Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _bidListRepository.Update(bidList);

            var bidLists = await _bidListRepository.FindAll();

            return Created(string.Empty, bidLists);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            BidList bidList = await _bidListRepository.FindById(id);

            if (bidList == null)
                throw new ArgumentException("Invalid bidList Id:" + id);

            _bidListRepository.Delete(bidList);

            return NoContent();
        }
    }
}