using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiscalFrontier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAcessor;

        public FileController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAcessor = httpContextAccessor;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file, int journalEntryId)
        {
            validateFileUpload(file);

            if (ModelState.IsValid) 
            {
                var fileRecord = new FileRecord
                {
                    FileName = Path.GetFileNameWithoutExtension(file.FileName).Trim(),
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    JournalEntryId = journalEntryId
                };

                fileRecord = await SaveFile(file, fileRecord);

                await dbContext.SaveChangesAsync();

                return Ok(fileRecord);
            }

            return BadRequest(ModelState);
        }


        private void validateFileUpload(IFormFile file)
        {
            var allowedExtensions = new String[] { ".jpeg", ".doc", ".docx", ".xls", ".xlsx", ".csv", ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format!");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File Size cannot be more than 10MB");
            }
        }

        private async Task<FileRecord> SaveFile(IFormFile file, FileRecord fileRecord)
        {
            var localPath = Path.Combine(webHostEnvironment.ContentRootPath, "Files", $"{fileRecord.FileName}{fileRecord.FileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            var httpRequest = httpContextAcessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.Path}/Files/{fileRecord.FileName}{fileRecord.FileExtension}";

            fileRecord.FileUrl = urlPath;

            await dbContext.FileRecords.AddAsync(fileRecord);
            await dbContext.SaveChangesAsync();

            return fileRecord;
        }
    }
}
