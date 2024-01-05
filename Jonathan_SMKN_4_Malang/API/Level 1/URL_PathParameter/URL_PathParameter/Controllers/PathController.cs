using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace URL_PathParameter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        [HttpGet("/pertama")]
        public IActionResult GetNama([FromQuery(Name = "nama")] string nama)
        {
            if (ModelState.IsValid)
            {
                return Ok($"Hello {nama}, are you lost?");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("/kedua/{id}")]
        public IActionResult GetPizzaOrder([FromRoute] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid pizza order ID.");
            }

            string responseMessage = $"You just ordered {id} pizza.";
            return Ok(responseMessage);
        }
    }
}
