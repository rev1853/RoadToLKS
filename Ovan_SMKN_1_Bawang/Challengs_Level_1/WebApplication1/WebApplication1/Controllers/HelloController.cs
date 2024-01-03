using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HelloController : ControllerBase
    {
        [HttpGet("Mengambil Data")]
        public string HelloWorld() 
        {
            return "Hello World!!!";
        }

        [HttpPost("Mengupload Data")]
        public string Helloworld1()
        {
            return "Halo anjing";
        }

        [HttpDelete("Menghapus Data")]
        public string Helloworld2()
        {
            return "Hapus aja buat apa disimen";
        }

        [HttpPut("Mengubah Data Secara Keseluruhan")]
        public string Helloworld3()
        {
            return "pur aja";
        }

        [HttpPatch("Mengubah Sebagian Data")]
        public string HelloWorld4()
        {
            return "DAMN";
        }

        
    }
}
