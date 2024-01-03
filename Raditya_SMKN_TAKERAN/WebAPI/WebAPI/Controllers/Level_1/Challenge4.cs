using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Runtime.InteropServices.JavaScript;

namespace WebAPI.Controllers.Level_1
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge4 : ControllerBase
    {
        [HttpPost]
       public ActionResult<string> Cek([FromBody] RequestData requestData)
        {
            if (requestData == null || string.IsNullOrEmpty(requestData.Nama) || string.IsNullOrEmpty(requestData.CitaCita))
            {
                return BadRequest("Request body tidak valid.");
            }

            string response = $"Dear {requestData.Nama} What an ambition, but are you worthy enough to achieve it?\nMy ambition is {requestData.CitaCita}";
            return Ok(response);
        }

        public class RequestData
        {
            public string Nama { get; set; }
            public string CitaCita { get; set; }
        }
    }
}
