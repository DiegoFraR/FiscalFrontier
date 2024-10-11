using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class AccountUpdateHistory
    {
        [Key]
        public int accountUpdateHistoryId { get; set; }
        public required int accountId { get; set; }
        public required DateTime updateDate { get; set; }
        public required string changes { get; set; }
    }
}
