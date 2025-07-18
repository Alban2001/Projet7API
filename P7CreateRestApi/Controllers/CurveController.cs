using Dot.Net.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dot.Net.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurveController : ControllerBase
    {
        // TODO: Inject Curve Point service

        [HttpGet]
        [Route("/Curves")]
        public IActionResult Curves()
        {
            return Ok();
        }

        [HttpPost]
        [Route("/Curves")]
        public IActionResult Create([FromBody]CurvePoint curvePoint)
        {
            return Ok();
        }

        //[HttpGet]
        //[Route("Curves")]
        //public IActionResult Validate([FromBody]CurvePoint curvePoint)
        //{
        //    // TODO: check data valid and save to db, after saving return bid list
        //    return Ok();
        //}

        [HttpGet]
        [Route("{id}")]
        public IActionResult Curve(int id)
        {
            // TODO: get CurvePoint by Id and to model then show to the form
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, [FromBody] CurvePoint curvePoint)
        {
            // TODO: check required fields, if valid call service to update Curve and return Curve list
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            // TODO: Find Curve by Id and delete the Curve, return to Curve list
            return Ok();
        }
    }
}