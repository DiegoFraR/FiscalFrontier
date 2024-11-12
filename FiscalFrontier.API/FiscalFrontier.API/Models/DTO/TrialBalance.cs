namespace FiscalFrontier.API.Models.DTO
{
    public class TrialBalance
    {
        public int ChartOfAccountId { get; set; }
        public required string ChartOfAccountName { get; set; }
        public decimal TotalDebits { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal NetBalance => TotalDebits - TotalCredits;

        //Could Maybe use this. Left it here for now. Might need to get the Journal Entry Description to make this better. 
        public List<DebitDetails>? DebitDetails { get; set; }
    }
}
