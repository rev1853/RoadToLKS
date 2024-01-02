using first.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace first.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(EsemkaHeroContext context) : ControllerBase
    {
        private readonly EsemkaHeroContext context = context;

        [HttpGet("/")]
        public List<Clan> Get()
        {
            return [.. this.context.Clans];
        }

        [HttpGet("/{id}")]
        public IActionResult FindById(int id)
        {
            var data = this.context.Clans.Find(id);

            if (data == null)
            {
                return StatusCode(400, new { Message = $"no dat id : {id}" });
            }
            else
            {
                return new JsonResult(data);
            }
        }

        [HttpPost("/add")]
        public IActionResult Post([FromBody] Clan data)
        {
            if (!string.IsNullOrEmpty(data.Name) && !string.IsNullOrEmpty(data.Description))
            {
                this.context.Add(data);
                if (this.context.SaveChanges()>0)
                return new JsonResult(new { message = "Success" });
                else
                {
                    var problemDetails = new ProblemDetails
                    {
                        Status = 500,
                        Title = "error",
                    };
                    return StatusCode(problemDetails.Status.Value, problemDetails);
                }
            }
            else {
                var problemDetails = new ProblemDetails
                {
                    Status = 401,
                    Title = "Data ada yang kosong",
                };
                return StatusCode(problemDetails.Status.Value, problemDetails);
             }
        }


        [HttpPut("/edit/{id}")]
        public IActionResult Update(int id, [FromBody] Clan data)
        {
            if (!string.IsNullOrEmpty(data.Description) || !string.IsNullOrEmpty(data.Name))
            {
                var existingClan = this.context.Clans.Find(id);
                if (existingClan != null)
                {
                    data.Id = id;
                    this.context.Attach(existingClan);
                    existingClan.Name = data.Name;
                    existingClan.Description = data.Description;

                    this.context.SaveChanges();
                    return new JsonResult(new { message = "Success Update" });
                }
                else
                {
                    return StatusCode(404, new { message = $"Entity with id {id} not found" });
                }

            }
            else
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 500,
                    Title = "error",
                };
                return StatusCode(problemDetails.Status.Value, problemDetails);
            }
        }

        [HttpDelete("/dellete/{id}")]
        public IActionResult Delete(int id) 
        {
            if (id != null)
            {
                var existingClan = this.context.Clans.Find(id);
                if (existingClan != null)
                {
                    this.context.Remove(existingClan);
                    this.context.SaveChanges();
                return new JsonResult(new { message = $"Success Delete id : {id}" });
                } else
                {
                    return StatusCode(400, new { Message = $"Entity with id {id} not found" });
                }
                

            }
            else
            {
                var problemDetails = new ProblemDetails
                {
                    Status = 500,
                    Title = "error",
                };
                return StatusCode(problemDetails.Status.Value, problemDetails);
            }
        }
    }
}
