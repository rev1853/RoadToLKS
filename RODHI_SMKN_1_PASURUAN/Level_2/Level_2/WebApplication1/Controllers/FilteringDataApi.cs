using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilteringDataApi(EsemkaCinemaContext context) : ControllerBase
    {
        EsemkaCinemaContext _context=context;

        [HttpGet("movie")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies([FromQuery] string search, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            IQueryable<Movie> query = _context.Movies;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.Title.Contains(search));
            }

            if (minPrice.HasValue)
            {
                decimal Decimal=Convert.ToDecimal(minPrice.Value);
                query = query.Where(m => (decimal)m.TicketPrice >= Decimal);
            }

            if (maxPrice.HasValue)
            {
                decimal DECIMAL = Convert.ToDecimal(maxPrice.Value);
                query = query.Where(m => (decimal)m.TicketPrice <= DECIMAL);

            }

            var movies = await query.ToListAsync();
            return Ok(movies);
        }

        [HttpGet("movie/{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
