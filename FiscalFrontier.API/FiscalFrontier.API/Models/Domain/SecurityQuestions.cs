using System.ComponentModel.DataAnnotations;

namespace FiscalFrontier.API.Models.Domain
{
    public class SecurityQuestions
    {
        [Key]
        public int securityQuestionId { get; set; }
        [Required]
        public required string securityQuestion { get; set; }
    }
}
