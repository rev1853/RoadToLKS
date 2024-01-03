using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level1
{
    [Route("api/level1/[controller]")]
    [ApiController]
    public class ReqJsonController : ControllerBase
    {
        [HttpPost]
        public string JsonRequest([FromBody] Profil req)
        {
            return $"Dear {req.nama}; What an ambition, but are you worthy enough to achieve it";
        }

        public class Profil
        {
            public required string nama { get; set; }
            public required string cita_cita { get; set; }
        }
    }
}
