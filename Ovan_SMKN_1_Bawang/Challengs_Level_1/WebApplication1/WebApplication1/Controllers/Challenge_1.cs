using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge_1 : ControllerBase
    {

        [HttpGet("/GetMethod")]
        public string Hello()
        {
            return "Hello there, this is the Get side";
        }

        [HttpPost("/PostMethod")]
        public string Hello1()
        {
            return "Hello there, this is the Post side";
        }

        [HttpPut("/PutMethod")]
        public string Hello2()
        {
            return "Hello there, this is the Put side";
        }

        [HttpDelete("/DeleteMethod")]
        public string Hello3()
        {
            return "Hello there, this is the DELETE side";
        }
    }
}
