namespace FiscalFrontier.API.Models.DTO
{
    public class ApproveJournalEntryDto
    {
        public required string updatedBy { get; set; }
        public required int journalEntryId { get; set; }
    }
}
