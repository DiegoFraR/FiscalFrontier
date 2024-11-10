using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class ErrorMessages
    {
        [Key]
        public int ErrorMessageId { get; set; }

        [Required]
        public required string ErrorMessage { get; set; }

        [Required]
        public required string ErrorMessageCategory { get; set; }
    }
}
