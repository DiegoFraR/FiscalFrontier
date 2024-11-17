namespace FiscalFrontier.API.Models.DTO
{
    public class BroadDetailJournalEntryDto
    {
        public int JournalEntryId { get; set; }
        public string? JournalEntryDescription { get; set; }
        public required string JournalEntryType { get; set; }
        public required string JournalEntryPostReference { get; set; }
        public required string CreatedBy { get; set; }
        public decimal CreditTotal { get; set; }
        public decimal DebitTotal { get; set; }
        public int ChartOfAccountId { get; set; }
        public string? ChartOfAccountName { get; set; }
        public string? FileLink { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
