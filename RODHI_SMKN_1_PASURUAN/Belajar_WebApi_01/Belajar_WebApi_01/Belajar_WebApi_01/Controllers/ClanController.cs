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
        public List<Clan> d()
        {
            return context.Clans.ToList();
        }

        [HttpGet("element")]
        public List<Element> e()
        {
            return context.Elements.ToList();
        }

        [HttpGet("fightHistory")]
        public List<FightHistory> fh()
        {
            return context.FightHistories.ToList();
        }

        [HttpGet("Hero")]
        public List<Hero> h()
        {
            return context.Heroes.ToList();
        }

        [HttpGet("HeroSkill")]
        public List<HeroSkill> hsk()
        {
            return context.HeroSkills.ToList();
        }

        [HttpGet("Skill")]
        public List<Skill> sk()
        {
            return context.Skills.ToList();
        }
    }
}
