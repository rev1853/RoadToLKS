using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge_3 : ControllerBase
    {
        [HttpGet("/pertama")]
        public string GetPertama([FromQuery] string nama)
        {
            return $"Hello {nama}, are you lost?";
        }

        [HttpGet("/kedua/{id}")]
        public string GetKedua(int id)
        {
            return $"You just ordered {id} pizza";
        }
    }
}
