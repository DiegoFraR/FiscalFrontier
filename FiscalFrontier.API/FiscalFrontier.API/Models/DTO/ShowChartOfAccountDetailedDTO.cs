using FiscalFrontier.API.Validations;
using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.DTO
{
    public class ShowChartOfAccountDetailedDTO
    {
        public required string accountName { get; set; }
        public required int accountNumber { get; set; }
        public required string accountDescription { get; set; }
        public required string accountNormalSide { get; set; }
        public required string accountCategory { get; set; }
        public required string accountSubcategory { get; set; }
        public required decimal accountInitialBalance { get; set; }
        public required decimal accountDebit { get; set; }
        public required decimal accountCredit { get; set; }
        public decimal accountBalance { get; set; }
        public required DateTime accountDateTimeAdded { get; set; }
        public Guid accountUserId { get; set; }
        public int accountOrder { get; set; }
        public required string accountStatement { get; set; }
        public string? accountComment { get; set; }
        public required Boolean accountActive { get; set; }
    }
}
