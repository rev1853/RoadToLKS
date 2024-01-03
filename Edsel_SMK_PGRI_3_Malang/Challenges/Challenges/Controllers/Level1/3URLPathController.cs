using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level1
{
    [Route("api/level1/[controller]")]
    [ApiController]
    public class URLPathController : ControllerBase
    {
        [HttpGet("pertama/{nama}")]
        public string Pertama(string nama)
        {
            return $"Hello {nama}, are you lost?";
        }


        [HttpGet("kedua/{id}")]
        public string Kedua(int id)
        {
            return $"You just ordered {id} pizza";
        }
    }
}
