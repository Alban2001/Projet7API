using Dot.Net.WebApi.Controllers.Domain;
using Dot.Net.WebApi.Domain;
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
        public async Task<IActionResult> Ratings()
        {
            var ratings = await _ratingRepository.FindAll();
            return Ok(ratings);
        }

        [HttpPost]
        [Route("/Rating")]
        public async Task<IActionResult> Create([FromBody]Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _ratingRepository.Add(rating);

            var ratings = await _ratingRepository.FindAll();

            return Ok(ratings);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Rating(int id)
        {
            Rating rating = await _ratingRepository.FindById(id);

            if (rating == null)
                throw new ArgumentException("Invalid rating Id:" + id);

            return Ok(rating);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Rating rating)
        {
            if (rating.Id != id)
                throw new ArgumentException("Invalid rating Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _ratingRepository.Update(rating);

            var ratings = await _ratingRepository.FindAll();

            return Ok(ratings);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Rating rating = await _ratingRepository.FindById(id);

            if (rating == null)
                throw new ArgumentException("Invalid rating Id:" + id);

            _ratingRepository.Delete(rating);

            var ratings = await _ratingRepository.FindAll();

            return Ok(ratings);
        }
    }
}