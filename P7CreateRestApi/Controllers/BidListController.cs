using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        private BidListRepository _bidListRepository;

        public BidListController(BidListRepository bidListRepository)
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

            return Ok(bidLists);
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

            return Ok(bidLists);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            BidList bidList = await _bidListRepository.FindById(id);

            if (bidList == null)
                throw new ArgumentException("Invalid bidList Id:" + id);

            _bidListRepository.Delete(bidList);

            var bidLists = await _bidListRepository.FindAll();

            return Ok(bidLists);
        }
    }
}