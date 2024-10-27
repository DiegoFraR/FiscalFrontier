using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalFrontier.API.Models.Domain
{
    public class Debit
    {
        [Key]
        public int DebitId { get; set; }

        [Required]
        public required int ChartOfAccountId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public required decimal DebitAmount { get; set; }

        [ForeignKey("ChartOfAccountId")]
        public virtual ChartOfAccount Account { get; set; }

        //Foreign Keys
        [Required]
        public required int JournalEntryId { get; set; }

        [ForeignKey("JournalEntryId")]
        public virtual JournalEntry JournalEntry { get; set; }
    }
}
