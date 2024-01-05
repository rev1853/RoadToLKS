using CRUD_File.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CRUD_File.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class File(BossLevelContext context) : ControllerBase
    {
        BossLevelContext context = context;
        [HttpGet] 
        public IActionResult Get([FromQuery] string?name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var data = context.CrudImages.Where(f => f.Name.Contains(name)).FirstOrDefault();
                if (data == null) return NotFound();
                string contextType = $"image/{data.ImagePath.Split("/").Last().Split(".").Last()}";

                return File(System.IO.File.OpenRead(data.ImagePath) ,contextType);
            }
            return Ok(context.CrudImages.ToList().Select(f => new { f.Id, f.Name}));
        }

        [HttpPost]
        public IActionResult Post([FromForm] string name, IFormFile fileData)
        {
            if (fileData == null || fileData.Length == 0)
                return BadRequest("No file was selected for upload.");
            if (string.IsNullOrEmpty(name))
                return BadRequest("Name Not null");

            if (context.CrudImages.Where(f => f.Name == name).FirstOrDefault() != null)
                return BadRequest("Name already in use");

            var uploadsFolder = Directory.GetCurrentDirectory()+"\\upload";

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);


            var fileName = Path.GetFileName(fileData.FileName).Split(".").First() + Guid.NewGuid().ToString().Substring(12) + Path.GetExtension(fileData.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                fileData.CopyTo(stream);
            }

            var hasil = new CrudImage
            {
                ImagePath = filePath,
                Name = name,
            };

            context.CrudImages.Add(hasil);
            context.SaveChanges();

            return Ok(hasil); ;
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id,[FromForm] string name,  IFormFile fileData)
        {
            if (fileData == null || fileData.Length == 0)
                return BadRequest("No file was selected for upload.");
            if (string.IsNullOrEmpty(name))
                return BadRequest("Name Not null");

            if (context.CrudImages.Where(f => f.Name == name).FirstOrDefault() != null)
                return BadRequest("Name already in use");

            CrudImage data = context.CrudImages.First(f => f.Id == id);
            System.IO.File.Delete(data.ImagePath);

            var uploadsFolder = Directory.GetCurrentDirectory() + "\\upload";

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Path.GetFileName(fileData.FileName).Split(".").First() + Guid.NewGuid().ToString().Substring(12) + Path.GetExtension(fileData.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                fileData.CopyTo(stream);
            }

            data.ImagePath = filePath;
            data.Name = name;
            context.CrudImages.Update(data);
            context.SaveChanges();

            return Ok(data);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = context.CrudImages.First(f => f.Id == id);
            context.CrudImages.Remove(data);
            System.IO.File.Delete(data.ImagePath);
            context.SaveChanges();
            return Ok(data);
        }
    }
}
