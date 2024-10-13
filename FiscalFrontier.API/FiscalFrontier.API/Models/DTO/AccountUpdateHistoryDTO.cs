namespace FiscalFrontier.API.Models.DTO
{
    public class AccountUpdateHistoryDTO
    {
        public required DateTime updateDate { get; set; }
        public required string changes { get; set; }
        public int accountUpdateHistoryId { get; set; }
        public int accountId { get; set; }
    }
}
