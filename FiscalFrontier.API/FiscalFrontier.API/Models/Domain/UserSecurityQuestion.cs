using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FiscalFrontier.API.Models.Domain
{
    public class UserSecurityQuestion
    {
        [Key]
        public int userSecurityQuestionId { get; set; }

        [ForeignKey("User")]
        public Guid userId { get; set; }

        public User user { get; set; }

        [ForeignKey("SecurityQuestions")]
        public int securityQuestionId { get; set; }

        public SecurityQuestions? securityQuestion { get; set; }

        [Required, NotNull]
        public required string answer { get; set; }
    }
}
