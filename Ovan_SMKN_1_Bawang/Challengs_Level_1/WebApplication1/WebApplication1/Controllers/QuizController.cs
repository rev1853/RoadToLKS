using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly QuizinAjaContext _context;

        public QuizController(QuizinAjaContext context)
        {
            _context = context;
        }

       // public IActionResult DisplayParticipants()
       // {
           
        //}
    }
}
