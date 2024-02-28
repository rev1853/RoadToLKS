using JWTAuthentication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(EsemkaCorporationContext context, IConfiguration configuration) : ControllerBase
    {

        private readonly EsemkaCorporationContext _context = context;
        private readonly IConfiguration _configuration = configuration;


        [HttpPost]
        public ActionResult Login([FromForm, DefaultValue("ahopewell0@people.com.cn")] string email, [FromForm, DefaultValue("vakWN5f3cajz")] string password)
        {
            var ff = Microsoft.EntityFrameworkCore.EF.Functions;
            
            _context.Employees.Where(f => ff.DateDiffYear(DateTime.Now, DateTime.Now.AddYears(4)) > 0);
            Employee? emp = _context.Employees.FirstOrDefault(e => e.Email == email && e.Password == password);
            if (emp == null) return NotFound(emp);

            string token = GenerateToken(emp);

            return Ok(new { 
                Token = token
            });
        }


        private string GenerateToken(Employee emp)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]!));
            Claim[] claims = [
                new(JwtRegisteredClaimNames.Sid, emp.Id.ToString(), ClaimValueTypes.Integer),
                new(JwtRegisteredClaimNames.Name, emp.Name)
            ];
            JwtSecurityToken token = new(
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(15),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
