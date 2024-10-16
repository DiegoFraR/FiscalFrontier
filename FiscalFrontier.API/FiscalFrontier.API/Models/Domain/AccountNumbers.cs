using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class AccountNumbers
    {
        [Key]
        public int accountNumbersId { get; set; }

        [Required]
        public required string accountCategory { get; set; }

        [Required]
        public required int accountNumber { get; set; }
    }
}
