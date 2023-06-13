using Microsoft.AspNetCore.Mvc;

namespace LinkAggregationApp.Controllers
{
    [Route("api/aggregate")]
    [ApiController]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{linkId}")]
        public ActionResult Get([FromRoute] int restaurantId, [FromRoute] int linkId)
        {
            
            return Ok();
        }

        [HttpGet("/{hashCode}")]
        public ActionResult Get([FromRoute] int restaurantId, [FromRoute] string hashCode)
        {

            return Ok();
        }
    }
}
