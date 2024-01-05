using JwtToken.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtToken.Controllers
{
    [ApiController]
    public class AuthController(EsemkaCorporationContext context, IConfiguration config) : ControllerBase
    {
        EsemkaCorporationContext context = context;
        IConfiguration config = config;

        [HttpPost, Route("/login")]
        public IActionResult Login([FromForm] string email, [FromForm] string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return BadRequest();

            var data = context.Employees.Where(f => f.Email == email && f.Password == password).FirstOrDefault();

            if (data == null) return BadRequest();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim> {new Claim(ClaimTypes.Sid, data.Id.ToString())};

            var tokenOptions = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }
    }
}
