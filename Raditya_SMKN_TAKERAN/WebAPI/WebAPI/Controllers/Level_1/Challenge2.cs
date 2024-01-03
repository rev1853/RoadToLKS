using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers.Level_1
{
    [Route("api/[controller]")]
    [ApiController]
    public class Challenge2 : ControllerBase
    {
        [HttpGet]
        public IActionResult JSonData()
        {

            var mydata = new PersonalData
            {
                Name = "Raditya Octa Syahputra",
                DateOfBirth = new DateTime(2006, 10, 18),
                School = "SMKN TAKERAN",
                Ambition = "Programmer"

            };
            return Ok(mydata);
        }
        
    }

    public class PersonalData
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string School { get; set; }
        public string Ambition { get; set; }
    }
}
