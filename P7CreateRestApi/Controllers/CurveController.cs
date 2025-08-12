using Dot.Net.WebApi.Domain;
using Dot.Net.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurveController : ControllerBase
    {
        // TODO: Inject Curve Point service
        private CurvePointRepository _curvePointRepository;

        public CurveController(CurvePointRepository curvePointRepository)
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

            return Ok(curves);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Curve(int id)
        {
            CurvePoint curvePoint = await _curvePointRepository.FindById(id);

            if (curvePoint == null)
                throw new ArgumentException("Invalid curve Id:" + id);

            return Ok(curvePoint);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CurvePoint curvePoint)
        {
            if (curvePoint.Id != id)
                throw new ArgumentException("Invalid curve Id:" + id);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _curvePointRepository.Update(curvePoint);

            var curves = await _curvePointRepository.FindAll();

            return Ok(curves);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CurvePoint curvePoint = await _curvePointRepository.FindById(id);

            if (curvePoint == null)
                throw new ArgumentException("Invalid curve Id:" + id);

            _curvePointRepository.Delete(curvePoint);

            var curves = await _curvePointRepository.FindAll();

            return Ok(curves);
        }
    }
}