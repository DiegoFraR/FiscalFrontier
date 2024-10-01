using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FiscalFrontier.API.Models.Domain
{
    public class UserSecurityQuestion
    {
        [Key]
        public int userSecurityQuestionId { get; set; }
        public required string userId { get; set; }

        public User user { get; set; }

        public SecurityQuestions? securityQuestion {  get; set; }

        public int securityQuestionId { get; set; }

        [Required, NotNull]
        public required string answer { get; set; }
    }
}
