using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckboxChallenge.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public IActionResult Get()
        {
            return File("~/Calculator.html", "text/html");
        }
    }
}
