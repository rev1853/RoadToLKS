using MenampilkanDataDariDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MenampilkanDataDariDatabase.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilteringController : ControllerBase
    {
        private readonly EsemkaCinemaContext _context;

        public FilteringController(EsemkaCinemaContext context)
        {
            _context = context;
        }

        [HttpGet("/movie")]
        public IActionResult GetMovies([FromQuery] string search, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            IQueryable<Movie> query = _context.Movies;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(movie => movie.Title.Contains(search));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(movie => movie.TicketPrice >= (double)minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(movie => movie.TicketPrice <= (double)maxPrice.Value);
            }

            var movies = query.ToList();
            return Ok(movies);
        }

        [HttpGet("/movie/{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
