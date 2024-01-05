using MenampilkanDataDariDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenampilkanDataDariDatabase.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController(EsemkaCinemaContext context) : ControllerBase
    {
        readonly EsemkaCinemaContext _context = context;

        [HttpGet("/dapat-data/movie")]
        public IActionResult Get()
        {
            return Ok(_context.Movies.ToList());
        }

        
    }
}
