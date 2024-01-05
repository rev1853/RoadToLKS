using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenampilkanDataDariDatabase.Models;

namespace MenampilkanDataDariDatabase.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TambahDataController : ControllerBase
    {
        private readonly EsemkaCinemaContext _context;

        public TambahDataController(EsemkaCinemaContext context)
        {
            _context = context;
        }

        [HttpPost("/movie")]
        public IActionResult TambahMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Invalid movie data");
            }

            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding movie: {ex.Message}");
            }
        }
    }
}
