using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BidListController : ControllerBase
    {
        [HttpGet]
        [Route("/BidLists")]
        public IActionResult AllBid()
        {
            // TODO: check data valid and save to db, after saving return bid list
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Bid(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("/BidLists")]
        public IActionResult Create([FromBody] BidList bidList)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] BidList bidList)
        {
            // TODO: check required fields, if valid call service to update Bid and return list Bid
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}