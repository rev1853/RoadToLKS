using Challenges_Level_1_ApiDasar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenges_Level_1_ApiDasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tampil_json_Format : ControllerBase
    {

        [HttpGet("Data diri")]
        public IActionResult c()
        {
            var data = new personal
            {
                nama = "Rodhi Firmansyah Akhmad",
                tgl = new DateTime(2007, 05, 06),
                asal = "SMKN 1 PASURUAN",
                cita = "PROGRAMMER"
            };
            return new JsonResult(data);
        }
    }
}
