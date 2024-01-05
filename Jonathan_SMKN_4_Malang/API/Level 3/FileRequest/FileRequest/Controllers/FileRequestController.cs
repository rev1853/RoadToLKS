using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace FileRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileRequestController : ControllerBase
    {
        //Tempat File Disimpan
        private const string FileUploadDirectory = "Uploaded";

        //Method Post
        [HttpPost("/upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            //Mengecek apakah file kosong
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file is selected for upload.");
            }

            //Rencana A
            try
            {
                //String path Directory "D:\Test WPF\FileRequest\FileRequest\Uploaded"
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), FileUploadDirectory);


                //cek jika fileuploaddirectory tidak ada, buatlah foldernya
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Mendapatka Nama File(bisa diubah)
                string fileName = $"{file.FileName}";
                //var fileName = $"{Guid.NewGuid()}_{file.FileName}";

                // Gabungkan Directory dan nama file
                var filePath = Path.Combine(directoryPath, fileName);

                // Simpan File ke Folder
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                // Generate URL untuk diakses User
                var fileUrl = $"{Request.Scheme}://{Request.Host}/{FileUploadDirectory}/{fileName}";

                return Ok(fileUrl);
            }

            //Rencana B
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
            }
        }
    }
}
