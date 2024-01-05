using BosLevelAlbum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BosLevelAlbum.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsemkaAlbum(EsemkaAlbumContext context, IWebHostEnvironment envi) : ControllerBase
    {
        readonly EsemkaAlbumContext _context = context;
        readonly IWebHostEnvironment _environment = envi;

        [HttpGet]
        public IActionResult get()
        {
            var result = _context.Images.ToList().Select(f => new {f.Id, f.Name});
            return Ok(result);
        }

        [HttpPost("/post")]
        public IActionResult post(IFormFile gambar, string nama)
        {
            if (gambar == null || gambar.Length == 0)
            {
                return BadRequest("File tidak ditemukan / kosong");
            }

            var sama = _context.Images.FirstOrDefault(f => f.Name == nama);
            if (sama != null)
            {
                return BadRequest($"Nama tidak boleh sama");
            }


            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(gambar.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Format file tidak didukung. Gunakan file dengan ekstensi .jpg, .jpeg, atau .png.");
            }

            try
            {
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "upload");

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                var fileName = $"{gambar.FileName}-{Guid.NewGuid().ToString().Substring(0, 12)}{fileExtension}";
                var filePath = Path.Combine(directoryPath, fileName);

                var album = new Image
                {
                    ImagePath = filePath,
                    Name = nama
                };

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    gambar.CopyTo(fileStream);
                }

                _context.Images.Add(album);
                _context.SaveChanges();

                return Ok("File berhasil diunggah.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Terjadi kesalahan: {ex.Message}");
            }
        }

        [HttpPut("/put/{id}")]
        public IActionResult put(IFormFile gambar, int id, string name )
        {
            //Validasi
            var fileini = _context.Images.FirstOrDefault(i => i.Id == id);
            if (fileini == null)
            {
                return NotFound();
            }

            var isNameUsed = _context.Images.FirstOrDefault(i => i.ImagePath == gambar.FileName);
            if (isNameUsed != null) 
            {
                return BadRequest("Nama Tidak boleh sama");
            }

            if (gambar == null || gambar.Length == 0)
            {
                return BadRequest("File tidak ditemukan / kosong");
            }


            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(gambar.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Format file tidak didukung. Gunakan file dengan ekstensi .jpg, .jpeg, atau .png.");
            }

            try
            {
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "upload");

                var fileName = $"{gambar.FileName}-{Guid.NewGuid().ToString().Substring(0, 12)}{fileExtension}";
                var filePath = Path.Combine(directoryPath, fileName);

                fileini.Name = name;
                fileini.ImagePath = filePath;

                _context.SaveChanges(); 
                
                return Ok("Data berhasil diganti");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult delete(int id)
        {
            var fileHapus = _context.Images.FirstOrDefault(h => h.Id == id);
            if (fileHapus == null)
            {
                return NotFound();
            }

            try
            {
                _context.Images.Remove(fileHapus);
                _context.SaveChanges();
                return Ok("Data Berhasil dihapus");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{nama}")]
        public IActionResult GetImage(string nama)
        {
            var gambarIni = _context.Images.FirstOrDefault(gi => gi.Name == nama);

            if (gambarIni == null)
            {
                return NotFound();
            }

            var filepath = gambarIni.ImagePath;

            if (!System.IO.File.Exists(filepath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var contentType = "image/png";

            return new FileContentResult(fileBytes, contentType);
        }

    }
}
