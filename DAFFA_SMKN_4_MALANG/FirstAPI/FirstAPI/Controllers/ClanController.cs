using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClanController(EsemkaHeroContext context) : ControllerBase
    {
        private readonly EsemkaHeroContext context = context;

        [HttpGet("/clan")]
        public List<Clan> All()
        {
            return this.context.Clans.ToList();
        }
    }
}
