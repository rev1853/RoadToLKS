using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MenampilkanDataDariDatabase.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MenampilkanDataDariDatabase.Controller
{
    [Route("api")]
    [ApiController]
    public class EsemkaCorporationController(EsemkaCorporationContext context,IConfiguration config) : ControllerBase
    {
        private readonly EsemkaCorporationContext _context = context;
        private readonly IConfiguration _config = config;

        [HttpPost("login")]
        public IActionResult Login(string email, string pass)
        {
            var user = _context.Employees.FirstOrDefault(u => u.Email == email && u.Password == pass);
            if (user != null)
            {
                var token = GenerateToken(user.Email);
                return Ok(new { token });
            }

            return Unauthorized("Authentication failed. Invalid email or password.");
        }

        [HttpGet("me")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUserData()
        {
            var userEmailClaim = User.FindFirst(ClaimTypes.Email);
            if (userEmailClaim != null)
            {
                var userData = new { Email = userEmailClaim.Value };
                return Ok(userData);
            }

            return Unauthorized("Unauthorized access.");
        }

        [HttpGet("department")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Ok(departments);
        }

        private string GenerateToken(string userEmail)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userEmail),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
