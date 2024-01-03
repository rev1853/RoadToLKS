using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge_4 : ControllerBase
    {
        [HttpPost("/postdata")]
        public string PostData([FromBody] JsonNode request)
        {

            var namaa = request["nama"];
            var yume = request["cita_cita"];

            if (namaa == null || yume == null)
            {
                return "'nama' dan 'cita_cita' harus diisi";
            }

            string nama = namaa.ToString();

            return $"Dear {nama}; What an ambition, but are you worthy enough to achieve it?"
;
        }
    }
}
