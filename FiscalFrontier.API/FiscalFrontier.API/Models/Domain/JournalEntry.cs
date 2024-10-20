using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class JournalEntry
    {
        [Key]
        public int JournalEntryId { get; set; }

        [Required]
        public required string JournalEntryType { get; set; }

        [Required]
        public required string JournalEntryDescription { get; set; }
        
        [Required]
        public required string CreatedBy { get; set; }

        [Required]
        public required string UpdatedBy { get; set; } = string.Empty;

        [Required]
        public required string JournalEntryPostReference { get; set; }

        public string JournalEntryStatus { get; set; } = "Pending";

        public string? JournalEntryRejectionReasoning {  get; set; }

        //Credit & Debit
        public virtual ICollection<Debit> Debits { get; set; } = new List<Debit>();

        public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();


        //Files
        public virtual ICollection<FileRecord>? Files { get; set; }

        public DateTime JournalEntryCreated {  get; set; } = DateTime.UtcNow;

        public DateTime JournalEntryUpdated {  get; set; } = DateTime.UtcNow;
    }
}
