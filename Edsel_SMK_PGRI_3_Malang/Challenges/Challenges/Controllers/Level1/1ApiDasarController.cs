using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level1
{
    [Route("api/level1/[controller]")]
    [ApiController]
    public class ApiDasarController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello there, this is the Get side";
        }
        [HttpPost]
        public string Post()
        {
            return "Hello there, this is the Post side";
        }
        [HttpPut]
        public string Put()
        {
            return "Hello there, this is the Put side";
        }
        [HttpDelete]
        public string Delete()
        {
            return "Hello there, this is the Delete side";
        }
    }
}
