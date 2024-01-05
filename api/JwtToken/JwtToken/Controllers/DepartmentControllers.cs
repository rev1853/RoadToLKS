using JwtToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtToken.Controllers
{
    [Route("/api")]
    [ApiController, Authorize]
    public class DepartmentControllers(EsemkaCorporationContext context) : ControllerBase
    {
        EsemkaCorporationContext context = context;

        [HttpGet("/department")]
        public List<Department> Get()
        {
            return context.Departments.Where(f => f.DeletedAt == null).ToList();
        }
    }
}
