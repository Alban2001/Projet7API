using Dot.Net.WebApi.Controllers.Domain;
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
    public class RatingController : ControllerBase
    {
        private IRatingRepository _ratingRepository;

        public RatingController(IRatingRepository ratingRepository)
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

            return Created(string.Empty, ratings);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Rating(int id)
        {
            Rating rating = await _ratingRepository.FindById(id);

            if (rating == null)
                return NotFound("Rating introuvable");

            return Ok(rating);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Rating rating)
        {
            Rating verifRating = await _ratingRepository.FindById(id);

            if (verifRating == null)
                return NotFound("Rating introuvable");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _ratingRepository.Update(rating);

            var ratings = await _ratingRepository.FindAll();

            return Created(string.Empty, ratings);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Rating rating = await _ratingRepository.FindById(id);

            if (rating == null)
                return NotFound("Rating introuvable");

            _ratingRepository.Delete(rating);

            return NoContent();
        }
    }
}