using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Dasar_C_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloAPI_Controller : ControllerBase
    {
        [HttpGet("/data")]
        public IActionResult Get()
        {
            return Ok("Hello There, this is the GET side");
        }

        [HttpPost("/data")]
        public IActionResult Post()
        {
            return Ok("Hello There, this is the Post side");
        }

        [HttpPut("/data")]
        public IActionResult Put()
        {
            return Ok("Hello There, this is the PUT side");
        }

        [HttpDelete("/data")]
        public IActionResult Delete()
        {
            return Ok("Hello There, this is the Delete side");
        }
    }
}
