using _01_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // mengambil singleton yang dibuat kedalam parameter constructor
    public class ClanController(EsemkaHeroContext context) : ControllerBase
    {
        // assign context pada parameter scope ke dalam property context
        private readonly EsemkaHeroContext context = context;

        [HttpGet("/ambil-data")]
        public List<Clan> All()
        {
            return this.context.Clans.ToList();
        }
    }
}
