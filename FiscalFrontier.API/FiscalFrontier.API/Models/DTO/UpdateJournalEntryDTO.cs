using FiscalFrontier.API.Models.Domain;

namespace FiscalFrontier.API.Models.DTO
{
    public class UpdateJournalEntryDTO
    {
        public int JournalEntryId { get; set; }
        public string? JournalEntryType { get; set; }
        public string? JournalEntryDescription { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? JournalEntryPostReference { get; set; }
        public string? JournalEntryStatus { get; set; }
        public string? JournalEntryRejectionReasoning { get; set; }
        public decimal accountCredit { get; set; }
        public decimal accountDebit { get; set; }
        public int? ChartOfAccountId { get; set; }
        public virtual ChartOfAccount? Account{get; set; }
        public virtual ICollection<Debit>? Debits { get; set; }
        public virtual ICollection<Debit>? Credits { get; set; }
        public virtual ICollection<FileRecord>? Files { get; set; }
        public DateTime? JournalEntryCreated { get; set; }
        public DateTime? JournalEntryUpdated { get; set; }
    }
}
