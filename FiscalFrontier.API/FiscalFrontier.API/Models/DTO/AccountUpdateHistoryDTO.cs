namespace FiscalFrontier.API.Models.DTO
{
    public class AccountUpdateHistoryDTO
    {
        public int accountUpdateHistoryId { get; set; }
        public string accountName { get; set; }
        public int? accountNumber { get; set; }
        public required DateTime updateDate { get; set; }
        public required string changes { get; set; }
        
        
    }
}
