using JWTAuthentication.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(EsemkaCorporationContext context) : ControllerBase
    {
        private readonly EsemkaCorporationContext _context = context;

        [HttpGet, Authorize]
        public ActionResult<List<Department>> All()
        {
            return _context.Departments.ToList();
        }

        [HttpGet("{id}"), AllowAnonymous]
        public ActionResult<Department> Find(int id)
        {
            Department? dep = _context.Departments.Find(id);
            if (dep == null) return NotFound("Data tidak ditemukan");
            return Ok(dep);
        }
    }
}
