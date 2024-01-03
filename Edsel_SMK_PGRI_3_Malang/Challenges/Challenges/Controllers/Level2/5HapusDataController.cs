using Challenges.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level2
{
    [Route("api/level2/[controller]")]
    [ApiController]
    public class HapusDataController : ControllerBase
    {
        EsemkaCinemaContext db = new EsemkaCinemaContext();

        [HttpDelete("movie/{id}")]
        public ActionResult Movie(int id)
        {
            var movie = db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null) return NotFound();
            db.Movies.Remove(movie);
            db.SaveChanges();
            return Ok(movie);
        }
    }
}
