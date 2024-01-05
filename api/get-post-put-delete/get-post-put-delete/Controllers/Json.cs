using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace get_post_put_delete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Json : ControllerBase
    {
        [HttpGet("/joson")]
        public IActionResult FormatJSON()
        {
            var data = new DataForData
            {
                id = 1,
                name = "Username",
                description = "description"
            };
            return new JsonResult(data);
        }
    }
}
