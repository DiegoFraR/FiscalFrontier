using FiscalFrontier.API.Data;
using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> UploadFile(UploadFileDto uploadRequest)
        {
            validateFileUpload(uploadRequest.File);

            if (ModelState.IsValid) 
            {
                var fileRecord = new FileRecord
                {
                    FileName = Path.GetFileNameWithoutExtension(uploadRequest.File.FileName).Trim(),
                    FileExtension = Path.GetExtension(uploadRequest.File.FileName).ToLower(),
                    JournalEntryId = uploadRequest.JournalEntryId
                };

                fileRecord = await SaveFile(uploadRequest.File, fileRecord);

                await dbContext.SaveChangesAsync();

                return Ok(fileRecord);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{journalEntryId}")]
        public async Task<IActionResult> GetFilesByJournalEntryId(int journalEntryId)
        {
            var files = await dbContext.FileRecords
                .Where(fr => fr.JournalEntryId == journalEntryId)
                .ToListAsync();

            if(files == null || !files.Any())
            {
                ModelState.AddModelError("NoFiles", "No Files are associated with this Journal Entry");
                return BadRequest(ModelState);
            }

            return Ok(files);
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
