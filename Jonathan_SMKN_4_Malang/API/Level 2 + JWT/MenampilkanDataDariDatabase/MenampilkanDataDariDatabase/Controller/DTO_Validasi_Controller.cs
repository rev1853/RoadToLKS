using MenampilkanDataDariDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MenampilkanDataDariDatabase.Controller
{
    public class MovieDTO
    {
        [Required(ErrorMessage = "Title Tidak Boleh Kosong!")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Harus berupa date! ex: 2022-01-01")]
        public DateOnly ReleaseDate { get; set; }

        [Required(ErrorMessage = "Ticket Price Tidak Boleh kosong")]
        [Range(1, float.MaxValue, ErrorMessage = "TicketPrice should be a number greater than or equal to 1.")]
        public float TicketPrice { get; set; }

        [Required(ErrorMessage = "Genre Gk boleh kosong!")]
        public string Genre { get; set; } = null!;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DTO_Validasi_Controller(EsemkaCinemaContext context) : ControllerBase
    {
        readonly EsemkaCinemaContext _context = context;

        [HttpPost("/movie1")]
        public IActionResult AddMovie([FromBody] MovieDTO movieDTO)
        {
            

            // Data valid, simpan ke database
            var newMovie = new Movie
            {
                Title = movieDTO.Title,
                ReleaseDate = movieDTO.ReleaseDate,
                TicketPrice = movieDTO.TicketPrice,
                Genre = movieDTO.Genre
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            // Keluarkan data yang telah ditambah
            return Ok(newMovie);
        }
    }


}

