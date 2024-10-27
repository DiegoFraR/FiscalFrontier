namespace FiscalFrontier.API.Models.DTO
{
    public class UploadFileDto
    {
        public required IFormFile File { get; set; }
        public int JournalEntryId { get; set; }
    }
}
