using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge_2 : ControllerBase
    {
        [HttpGet("/Get")]
        public string DataPribadi()
        {
            var dataSaya = new
            {
                nama = "'Adn Asa Giovanni Budiarso",
                tanggal_lahir = "17 Desember 2006",
                asal_sekolah = "SMKN 1 Bawang",
                cita_cita = "Sukses Dunia Akhirat"
            };

            return dataSaya.ToString();
        }
    }
}
