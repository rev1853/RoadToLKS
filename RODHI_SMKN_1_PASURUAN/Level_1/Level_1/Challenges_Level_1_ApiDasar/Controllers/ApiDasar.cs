using Challenges_Level_1_ApiDasar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges_Level_1_ApiDasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDasar(EsemkaHeroContext context) : ControllerBase
    {
        EsemkaHeroContext context = context;


        [HttpGet("GET")]
        public string h()
        {
            return "Hello there, this is the GET ";
        }
        
        [HttpPost("POST")]
        public string p()
        {
            return "Hello there, this is the POST ";
        } 
        
        [HttpPut("PUT")]
        public string a()
        {
            return "Hello there, this is the PUT ";
        }
        
        [HttpDelete("DELETE")]
        public string d()
        {
            return "Hello there, this is the DELETE ";
        } 
    }
}
