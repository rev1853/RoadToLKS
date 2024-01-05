using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace get_post_put_delete.Controllers
{
    public class DataBeratBadan
    {
        public string nama { get; set; }
        public string jenisKelamin { get; set; }
        public int umur { get; set; }
        public int tinggiBadan { get; set; }
        public int beratBadan { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class HitungBeratBadan : ControllerBase
    {
        [HttpPost("/hitungBeratBadan")] 
        public string Post([FromBody] DataBeratBadan data)
        {
            double pria = (data.tinggiBadan - 100) - (data.tinggiBadan - 100 * .1);
            double wanita = (data.tinggiBadan - 100) - (data.tinggiBadan - 100 * .15);

            if (data.jenisKelamin == "pria")
            {
                if (pria == data.beratBadan) return $"Selamat {data.nama}, berat badan anda Ideal";
                else if (pria > data.beratBadan) return $"Selamat {data.nama}, berat badan anda Obesitas";
                else return $"Selamat {data.nama}, berat badan anda Kurang";
            } else
            {
                if (wanita == data.beratBadan) return $"Selamat {data.nama}, berat badan anda Ideal";
                else if (wanita > data.beratBadan) return $"Selamat {data.nama}, berat badan anda Obesitas";
                else return $"Selamat {data.nama}, berat badan anda Kurang";
            }
        }
    }
}
