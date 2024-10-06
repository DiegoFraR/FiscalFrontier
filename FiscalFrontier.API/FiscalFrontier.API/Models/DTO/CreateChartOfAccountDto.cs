using FiscalFrontier.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.DTO
{
    public class CreateChartOfAccountDto
    {
        [Required]
        public required string accountName { get; set; }

        [Required]
        public required string accountNumber { get; set; }

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
        public required string accountStatement { get; set; }

        [Required]
        public int accountOrder {  get; set; }

        [Required]
        public string? accountComment { get; set; }
    }
}
