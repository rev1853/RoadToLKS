using JwtToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtToken.Controllers
{
    [Route("/")]
    [ApiController]
    public class User(EsemkaCorporationContext context) : ControllerBase
    {
        EsemkaCorporationContext context = context;
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            int userId = int.Parse(User.Claims.First(f => f.Type == ClaimTypes.Sid).Value);
            var data = context.Employees.First(f => f.Id == userId);
            return Ok(data);
        }
    }
}
