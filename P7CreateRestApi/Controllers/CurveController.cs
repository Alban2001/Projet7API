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
    public class CurveController : ControllerBase
    {
        private ICurvePointRepository _curvePointRepository;

        public CurveController(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }

        [HttpGet]
        [Route("/Curves")]
        public async Task<IActionResult> Curves()
        {
            var curves = await _curvePointRepository.FindAll();
            return Ok(curves);
        }

        [HttpPost]
        [Route("/Curve")]
        public async Task<IActionResult> Create([FromBody]CurvePoint curvePoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _curvePointRepository.Add(curvePoint);

            var curves = await _curvePointRepository.FindAll();

            return Created(string.Empty, curves);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Curve(int id)
        {
            CurvePoint curvePoint = await _curvePointRepository.FindById(id);

            if (curvePoint == null)
                return NotFound("Curve introuvable");

            return Ok(curvePoint);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CurvePoint curvePoint)
        {
            if (curvePoint.Id != id)
                return NotFound("Curve introuvable");

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _curvePointRepository.Update(curvePoint);

            var curves = await _curvePointRepository.FindAll();

            return Created(string.Empty, curves);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CurvePoint curvePoint = await _curvePointRepository.FindById(id);

            if (curvePoint == null)
                return NotFound("Curve introuvable");

            _curvePointRepository.Delete(curvePoint);

            return NoContent();
        }
    }
}