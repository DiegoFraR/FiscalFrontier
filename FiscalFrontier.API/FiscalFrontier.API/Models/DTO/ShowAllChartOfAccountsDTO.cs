namespace FiscalFrontier.API.Models.DTO
{
    public class ShowAllChartOfAccountsDTO
    {
        public int accountNumber {  get; set; }
        public required string accountDescription { get; set; }
        public required string accountCategory { get; set; }
        public required string accountSubcategory { get; set; }
        public decimal accountBalance { get; set; }
        public string? accountComment { get; set; }
        public required Boolean accountActive { get; set; }
    }
}
