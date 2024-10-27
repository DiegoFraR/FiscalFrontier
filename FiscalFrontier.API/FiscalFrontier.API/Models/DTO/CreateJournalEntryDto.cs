using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.DTO
{
    public class CreateJournalEntryDto
    {
        [Required(ErrorMessage = "Journal Entry Type is required.")]
        public required string JournalEntryType { get; set; }
        [Required(ErrorMessage = "Journal Entry Description is required.")]
        public required string JournalEntryDescription { get; set; }
        [Required(ErrorMessage = "An Error Occured passing your Id to the API. Please try again later!")]
        public required string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        [Required(ErrorMessage = "Journal Entry Post Reference is required.")]
        public required string JournalEntryPostReference { get; set; }
        public DateTime JournalEntryCreated { get; set; } = DateTime.UtcNow;
        public DateTime JournalEntryUpdated {  get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "An Error Occured passing the Account ID to the API. Please try again later!")]
        public required int ChartOfAccountId { get; set; }
        public required List<decimal> CreditValues { get; set; }
        public required List<decimal> DebitValues { get; set; }

    }
}
