using Challenges.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level2
{
    [Route("api/level2/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        EsemkaCinemaContext db = new EsemkaCinemaContext();

        [HttpGet("movie")]
        public ActionResult Movie()
        {
            return Ok(db.Movies.ToList());
        }
    }
}
