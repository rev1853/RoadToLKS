using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges_Level_1_ApiDasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLdanParameter : ControllerBase
    {
        [HttpGet("pertama")]
        public IActionResult pertama([FromQuery]string nama)
        {
            if (string.IsNullOrEmpty(nama))
            {
                return BadRequest("Parameter 'nama is required");
            }
            string response = $"Hello {nama}, are you lost?";
            return Ok(response);
        }


        [HttpGet("kedua/{id}")]
        public IActionResult Kedua(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id value. Id should be greater than 0.");
            }

            string response = $"You just ordered {id} pizza";
            return Ok(response);
        }


    }

}

