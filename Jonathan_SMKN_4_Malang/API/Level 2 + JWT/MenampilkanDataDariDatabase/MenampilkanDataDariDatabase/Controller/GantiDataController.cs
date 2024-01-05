using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenampilkanDataDariDatabase.Models;

namespace MenampilkanDataDariDatabase.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GantiDataController : ControllerBase
    {
        private readonly EsemkaCinemaContext _context;

        public GantiDataController(EsemkaCinemaContext context)
        {
            _context = context;
        }

        [HttpPut("/movie/{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var existingMovie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (existingMovie == null)
            {
                return NotFound("Movie not found with the specified ID.");
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.TicketPrice = updatedMovie.TicketPrice;

            try
            {
                _context.SaveChanges();
                return Ok(existingMovie);
            }
            catch (DbUpdateException)
            {
                // Handle update failure
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the movie.");
            }
        }
    }
}
