namespace FiscalFrontier.API.Models.DTO
{
    public class DebitDetails
    {
        public int DebitId { get; set; }
        public int ChartOfAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
