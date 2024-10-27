namespace FiscalFrontier.API.Models.DTO
{
    public class DenyJournalEntryDto
    {
        public int journalEntryId { get; set; }
        public required string journalEntryDeniedReason { get; set; }
        public required string updatedBy { get; set; }
    }
}
