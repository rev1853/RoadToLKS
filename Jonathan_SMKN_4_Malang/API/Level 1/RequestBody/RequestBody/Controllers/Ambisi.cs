using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestBody.Models;

namespace RequestBody.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ambisi : ControllerBase
    {
        [HttpPost]
        public IActionResult PostAmbition([FromBody] Ambition request)
        {
            if (request == null || string.IsNullOrEmpty(request.FullName) || string.IsNullOrEmpty(request.CitaCita))
            {
                return BadRequest("Invalid request body. Please provide 'nama' and 'cita-cita' in the JSON.");
            }

            string responseMessage = $"Dear {request.FullName}; What an ambition, but are you worthy enough to achieve it?";
            return Ok(responseMessage);
        }
    }
}
