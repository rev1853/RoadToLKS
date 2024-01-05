using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace get_post_put_delete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlParam : ControllerBase
    {
        [HttpGet("/pertama")]
        public string GetPertama([FromQuery] string name)
        {
            return $"Hello {name}, are you lost?";
        }

        [HttpGet("/kedua/{id}")]
        public string GetKedua(int id)
        {
            return $"You just ordered {id} pizza";
        }
    }
}
