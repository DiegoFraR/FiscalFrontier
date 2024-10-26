using FiscalFrontier.API.Models.Domain;

namespace FiscalFrontier.API.Models.DTO
{
    public class ShowJournalEntryDTO
    {

        public required string JournalEntryType { get; set; }

        public required string JournalEntryDescription { get; set; }

        public required string CreatedBy { get; set; }

        public required string UpdatedBy { get; set; } = string.Empty;

        public required string JournalEntryPostReference { get; set; }

        public string JournalEntryStatus { get; set; }

        public string? JournalEntryRejectionReasoning { get; set; }

        public int ChartOfAccountId { get; set; }
        public virtual ChartOfAccount Account { get; set; }


        public virtual ICollection<Debit> Debits { get; set; } = new List<Debit>();

        public virtual ICollection<Credit> Credits { get; set; } = new List<Credit>();

        public virtual ICollection<FileRecord>? Files { get; set; }

        public DateTime JournalEntryCreated { get; set; } = DateTime.UtcNow;

        public DateTime JournalEntryUpdated { get; set; } = DateTime.UtcNow;
    }
}
