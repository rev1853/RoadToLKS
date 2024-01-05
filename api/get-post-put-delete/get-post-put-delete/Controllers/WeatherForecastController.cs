using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace get_post_put_delete.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

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
    }
}
