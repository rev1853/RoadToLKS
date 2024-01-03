using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Level_1
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge3 : ControllerBase
    {
        [HttpGet("pertama")]
        public IActionResult Pertama([FromQuery] string nama)
        {
            string pesan = $"Hello {nama}, are you lost?";
            return Ok(pesan);
        }

        [HttpGet("kedua/{id}")]
        public IActionResult kedua(int id)
        {
            string pesan = $"You just ordered {id} pizza";
            return Ok(pesan);  
        }
    }
}
