using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        // GET: api/hello
        [HttpGet]
        public IActionResult GetHello()
        {
            return Ok(new { message = "Hello from your first custom API! 🎉" });
        }

        // GET: api/hello/{name}
        [HttpGet("{name}")]
        public IActionResult GetHelloByName(string name)
        {
            return Ok(new { message = $"Hello, {name}! 👋" });
        }
    }
}
