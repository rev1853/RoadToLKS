using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace get_post_put_delete.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        List<DataForData> data = new List<DataForData> {
            new DataForData { name = "nedy", description = "progamer terbaik", id = 1 },
            new DataForData { name = "barakuda", description = "penunggang kuda terbaik", id = 2 },
            new DataForData { name = "zara", description = "pencinta hewan", id = 3 },
            new DataForData { name = "delta", description = "petualang sejati", id = 4 },
            new DataForData { name = "echo", description = "pemecah teka-teki", id = 5 },
            new DataForData { name = "foxtrot", description = "seniman ulung", id = 6 },
            new DataForData { name = "golf", description = "ahli olahraga", id = 7 },
            new DataForData { name = "hotel", description = "pengelana waktu", id = 8 },
            new DataForData { name = "indigo", description = "rahasia gelap", id = 9 },
            new DataForData { name = "juliet", description = "penulis berbakat", id = 10 }
        };

       [HttpGet("/")]
        public string Get()
        {
            return $"hello there this is from method {MethodBase.GetCurrentMethod().Name}";
        }

        [HttpPost("/")]
        public string Post()
        {
            return $"hello there this is from method {MethodBase.GetCurrentMethod().Name}";
        }

        [HttpPut("/")]
        public string Put()
        {
            return $"hello there this is from method {MethodBase.GetCurrentMethod().Name}";
        }

        [HttpDelete("/")]
        public string Delete()
        {
            return $"hello there this is from method {MethodBase.GetCurrentMethod().Name}";
        }
        
        [HttpGet("/joson")]
        public IActionResult FormatJSON()
        {
            var data = new DataForData
            {
                id = 1,
                name = "Username",
                description = "description"
            };
            return new JsonResult(data);
        }

        [HttpGet("/kedua/{id}")]
        public IActionResult ParameterPertama(int id)
        {
            return new JsonResult(this.data.FindAll(f => f.id == id));
        }

        [HttpGet("/pertama")]
        public IActionResult PostKedua([FromQuery] string name) 
        {
            return new JsonResult(this.data.FindAll(f => f.name.Contains(name)));
        }
    }
}
