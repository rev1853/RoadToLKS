using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenampilkanDataDariDatabase.Models;

namespace MenampilkanDataDariDatabase.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HapusDataController : ControllerBase
    {
        private readonly EsemkaCinemaContext _context;

        public HapusDataController(EsemkaCinemaContext context)
        {
            _context = context;
        }

        [HttpDelete("/movie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieToDelete == null)
            {
                return NotFound("Movie not found with the specified ID.");
            }

            try
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
                return Ok(movieToDelete);
            }
            catch (DbUpdateException)
            {
                // Handle delete failure
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete the movie.");
            }
        }
    }
}
