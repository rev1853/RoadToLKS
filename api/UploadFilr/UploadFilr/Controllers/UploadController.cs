using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UploadFilr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file was selected for upload.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "upload");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var fileUrl = $"{Request.Scheme}://{Request.Host}/img/{fileName}";

            return Ok(new { FileUrl = fileUrl });
        }
    }
}
