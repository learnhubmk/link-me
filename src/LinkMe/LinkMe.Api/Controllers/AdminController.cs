using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkMe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You have accessed the Admin controller.");
        }
    }
}
