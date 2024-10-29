namespace FiscalFrontier.API.Models.DTO
{
    public class DetailedJournalEntryDto
    {
        public int JournalEntryId { get; set; }
        public required string JournalEntryType { get; set; }
        public required string JournalEntryDescription { get; set; }
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public required string JournalEntryPostReference { get; set; }
        public required string JournalEntryStatus { get; set; }
        public string? JournalEntryRejectionReasoning { get; set; }
        public required int ChartOfAccountId { get; set; }
        public required decimal[] CreditValues { get; set; }
        public required decimal[] DebitValues { get; set; }
        public string? FileUrl { get; set; }
        public string? FileName { get; set; }
        public required DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
