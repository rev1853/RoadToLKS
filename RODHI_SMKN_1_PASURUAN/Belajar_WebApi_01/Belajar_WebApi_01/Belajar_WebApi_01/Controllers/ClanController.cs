using Belajar_WebApi_01.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Belajar_WebApi_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClanController(EsemkaHeroContext context) : ControllerBase
    {
        EsemkaHeroContext context = context;

        [HttpGet("clan")]
        public List<Clan> s()
        {
            return context.Clans.ToList();
        }
    }
}
