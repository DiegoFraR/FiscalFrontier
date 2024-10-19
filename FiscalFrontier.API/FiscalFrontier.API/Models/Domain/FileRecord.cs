using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class FileRecord
    {
        [Key]
        public int FileId { get; set; }

        [Required]
        public required string FileName { get; set; }

        [Required]
        public required string FileExtension { get; set; }

        [Required]
        public required int JournalEntryId { get; set; }

        [Required]
        public string? FileUrl { get; set; }
    }
}
