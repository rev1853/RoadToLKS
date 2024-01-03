using Challenges.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level2
{

    [Route("api/level2/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        EsemkaCinemaContext db = new EsemkaCinemaContext();

        [HttpGet("movie")]
        public ActionResult Movie(string? search = null, int? minPrice = null, int? maxPrice = null)
        {
            var movie = db.Movies.ToList();

            if (search != null) movie = movie.Where(m => m.Title.Contains(search)).ToList();
            if (minPrice != null) movie = movie.Where(m => m.TicketPrice >= minPrice).ToList();
            if (maxPrice != null) movie = movie.Where(m => m.TicketPrice <= maxPrice).ToList();

            return Ok(movie);
        }

        [HttpGet("movie/{id}")]
        public ActionResult MovieById(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);
            return movie != null ? Ok(movie) : NotFound();
        }
    }
}
