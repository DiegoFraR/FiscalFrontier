using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Navigation property back to the JournalEntry
        [ForeignKey("JournalEntryId")]
        public virtual JournalEntry JournalEntry { get; set; }
    }
}
