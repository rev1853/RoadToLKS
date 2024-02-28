using HeroAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController(EsemkaHeroContext context) : ControllerBase
    {
        private readonly EsemkaHeroContext context = context;

        [HttpGet]
        public List<Element> All()
        {
            return context.Elements.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Element> Find(int id)
        {
            Element? element = context.Elements.FirstOrDefault(el => el.Id == id);
            if (element == null) return NotFound();
            return element;
        }

        [HttpPost]
        public Element Store([FromBody] Element element)
        {
            context.Elements.Add(element);
            context.SaveChanges();
            return element;
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Element> Update(int id, [FromBody] Element element)
        {
            Element? oldElement = context.Elements.Find(id);
            if (oldElement == null) return NotFound();

            oldElement.Element1 = element.Element1;
            context.SaveChanges();

            return oldElement;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Element> Destroy(int id)
        {
            try
            {
                Element? oldElement = context.Elements.Find(id);
                if (oldElement == null) return NotFound();

                context.Elements.Remove(oldElement);
                context.SaveChanges();

                return oldElement;
            } catch
            {
                return BadRequest();
            }
        }

    }
}
