using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.Controllers.Level1
{
    [Route("api/level1/[controller]")]
    [ApiController]
    public class FormatJsonController : ControllerBase
    {
        [HttpGet]
        public IActionResult Json()
        {
            var profil = new Profil
            {
                nama = "Edsel",
                tanggal_lahir = DateOnly.Parse("2006/9/19"),
                asal_sekolah = "SMK PGRI 3 Malang",
                cita_cita = "Programmer"
            };

            return Ok(profil);
        }

        class Profil
        {
            public string nama { get; set; }
            public DateOnly tanggal_lahir { get; set; }
            public string asal_sekolah { get; set; }
            public string cita_cita { get; set; }
        }
    }
}
