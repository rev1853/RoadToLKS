using Challenges.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level2
{
    [Route("api/level2/[controller]")]
    [ApiController]
    public class NgubahDataController : ControllerBase
    {
        EsemkaCinemaContext db = new EsemkaCinemaContext();

        [HttpPut("movie/{id}")]
        public ActionResult Movie(int id, [FromBody]MovieRequest movie)
        {
            var movieReq = db.Movies.FirstOrDefault(m => m.Id == id);
            if (movieReq == null) return NotFound();

            movieReq.Id = id;
            movieReq.Title = movie.title;
             movieReq.ReleaseDate = DateOnly.Parse(movie.release_data);
            movieReq.Genre = movie.genre;
            movieReq.TicketPrice = movie.ticket_price;

            db.Movies.Update(movieReq);
            db.SaveChanges();
            return Ok(db.Movies.FirstOrDefault(x => x.Id == id));
        }
    }
}
