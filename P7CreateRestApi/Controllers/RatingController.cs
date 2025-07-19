using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        // TODO: Inject Rating service
        private RatingRepository _ratingRepository;

        public RatingController(RatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        [HttpGet]
        [Route("/Ratings")]
        public IActionResult Ratings()
        {
            // TODO: find all Rating, add to model
            return Ok();
        }

        //[HttpGet]
        //[Route("add")]
        //public IActionResult AddRatingForm([FromBody]Rating rating)
        //{
        //    return Ok();
        //}

        [HttpPost]
        [Route("/Ratings")]
        public IActionResult Create([FromBody]Rating rating)
        {
            // TODO: check data valid and save to db, after saving return Rating list
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Rating(int id)
        {
            // TODO: get Rating by Id and to model then show to the form
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] Rating rating)
        {
            // TODO: check required fields, if valid call service to update Rating and return Rating list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Find Rating by Id and delete the Rating, return to Rating list
            return Ok();
        }
    }
}