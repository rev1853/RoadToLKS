using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {

        [HttpGet("/")]
        public string HelloWorld()
        {
            return "Hello world!!";
        }

        [HttpPost("/")]
        public string HelloWorld1()
        {
            return "Hello world with POST method!!";
        }

        [HttpPut("/")]
        public string HelloWorld2()
        {
            return "Hello world with PUT method!!";
        }

        [HttpDelete("/")]
        public string HelloWorld3()
        {
            return "Hello world with DELETE method!!";
        }
    }
}
