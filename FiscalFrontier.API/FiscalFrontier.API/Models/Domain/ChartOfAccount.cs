using FiscalFrontier.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class ChartOfAccount
    {
        [Key]
        public int accountId { get; set; }

        [Required]
        [StringLength(100)]
        public required string accountName { get; set; }

        [Required]
        [AccountNumberValidation]
        [StringLength (20)]
        public required int accountNumber { get; set; }

        [Required]
        public required string accountDescription { get; set; }

        [Required]
        public required string accountNormalSide { get; set; }

        [Required]
        public required string accountCategory { get; set; }

        [Required]
        public required string accountSubcategory { get; set; }

        [Required]
        [TwoDecimalPlacesValidation]
        [Range(0, Double.MaxValue)]
        public required decimal accountInitialBalance { get; set; }

        [Required]
        [TwoDecimalPlacesValidation]
        [Range(0, Double.MaxValue)]
        public required decimal accountDebit { get; set; }

        [Required]
        [TwoDecimalPlacesValidation]
        [Range(0, Double.MaxValue)]
        public required decimal accountCredit { get; set; }

        [Required]
        [TwoDecimalPlacesValidation]
        public decimal accountBalance { get; set; }

        [Required]
        public required DateTime accountDateTimeAdded { get; set; }

        [Required]
        public Guid accountUserId { get; set; }

        public int accountOrder { get; set; }

        [Required] 
        public required string accountStatement { get; set; }

        [Required]
        public string? accountComment { get; set; }

        [Required]
        public required Boolean accountActive { get; set; } 
    }
}
