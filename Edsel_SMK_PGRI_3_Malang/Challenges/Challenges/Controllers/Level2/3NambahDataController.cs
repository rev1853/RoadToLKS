using Challenges.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Challenges.Controllers.Level2
{
    [Route("api/level2/[controller]")]
    [ApiController]
    public class NambahDataController : ControllerBase
    {
        EsemkaCinemaContext db = new EsemkaCinemaContext();

        [HttpPost("movie")]
        public ActionResult Movie([FromBody] MovieRequest movie)
        {
            var lastIndex = db.Movies.OrderByDescending(x => x.Id).FirstOrDefault();

            var insertedMovie = new Movie
            {
                Id = lastIndex != null ? lastIndex.Id+1 : 0,
                Title = movie.title,
                ReleaseDate = DateOnly.Parse(movie.release_data),
                TicketPrice = movie.ticket_price,
                Genre = movie.genre,
            };

            db.Movies.Add(insertedMovie);
            db.SaveChanges();

            return Ok(db.Movies.FirstOrDefault(m => m.Id == insertedMovie.Id));
        }

        
    }
}
