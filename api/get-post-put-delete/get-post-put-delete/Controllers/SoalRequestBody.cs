using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace get_post_put_delete.Controllers
{
    public class DataRequestBody
    {
        public string name { get; set; }
        public string citaCita { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SoalRequestBody : ControllerBase
    {
        [HttpPost("/requestBody")]
        public string Post([FromBody] DataRequestBody data)
        {
            return $"Dear {data.name} What an ambition, but are you worthy enough to achieve it?";
        }
    }
}
