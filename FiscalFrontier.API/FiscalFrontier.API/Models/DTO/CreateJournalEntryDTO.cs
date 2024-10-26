using FiscalFrontier.API.Models.Domain;
using FiscalFrontier.API.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalFrontier.API.Models.DTO
{
    public class CreateJournalEntryDTO
    {
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

        public string JournalEntryStatus { get; set; }

        public string? JournalEntryRejectionReasoning { get; set; }

        [Required]
        public int ChartOfAccountId { get; set; }

        [ForeignKey("ChartOfAccountId")]
        public virtual ChartOfAccount Account { get; set; }


        //Credit & Debit
        //public required decimal Debits = new Debit[];

        //public required decimal Credits = new Credit[];

        public virtual ICollection<Debit> Debits { get; set; } = new List<Debit>();

        public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();


        //Files
        public virtual ICollection<FileRecord>? Files { get; set; }

        public DateTime JournalEntryCreated { get; set; } = DateTime.UtcNow;

        public DateTime JournalEntryUpdated { get; set; } = DateTime.UtcNow;
    }
}
