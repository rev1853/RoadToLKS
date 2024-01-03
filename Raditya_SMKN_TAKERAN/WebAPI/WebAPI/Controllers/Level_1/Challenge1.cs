using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace WebAPI.Controllers.Level_1
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge1 : ControllerBase
    {
        [HttpGet("/GetMethod")]
        public string hello()
        {
            return "Hello There, This is the Get Side ";
        }

        [HttpPost("/PostMethod")]
        public string hello2()
        {
            return "Hello There, This is the Post Side";
        }

        [HttpPut("/PutMethod")]
        public string hello3()
        {
            return "Hello There, This is the Put Side";
        }

        [HttpDelete("/DeleteMethod")]
        public string hello4()
        {
            return "Hello There, This is the Delete Side";
        }
    }
}
