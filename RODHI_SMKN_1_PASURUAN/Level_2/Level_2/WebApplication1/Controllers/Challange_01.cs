using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieChinema(EsemkaCinemaContext context) : ControllerBase
    {
        EsemkaCinemaContext Context = context;


        [HttpGet("/Movie")]
        public List<Movie> m()
        {
            return Context.Movies.ToList();
        }
    }
}
