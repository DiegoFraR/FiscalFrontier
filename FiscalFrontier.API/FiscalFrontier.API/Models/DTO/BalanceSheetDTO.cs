namespace FiscalFrontier.API.Models.DTO
{
    public class BalanceSheetDTO
    {
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal TotalEquity { get; set; }
        public decimal NetWorth { get; set; }

    }
}
