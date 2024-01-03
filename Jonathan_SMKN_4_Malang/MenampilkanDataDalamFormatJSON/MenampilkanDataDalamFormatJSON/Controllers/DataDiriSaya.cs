using MenampilkanDataDalamFormatJSON.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenampilkanDataDalamFormatJSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataDiriSaya : ControllerBase
    {
       [HttpGet("/data")]
       public IActionResult GetDataDiri()
        {
            var datadiri = new DataDiri
            {
                Nama = "Jonathan Emmanuel Kristanto",
                Tanggal_Lahir = "1 Januari 2007",
                Asal_Sekolah = "SMKN 4 Malang",
                Cita_Cita = "Programer"
            };

            return Ok(datadiri);
        }
    }
}
