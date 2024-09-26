using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalFrontier.API.Models.Domain
{
    public class User : IdentityUser
    {
        [Required]
        public required string firstName { get; set; }

        [Required]
        public required string lastName { get; set; }

        [Required]
        public required string address { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [Required]
        public DateTime createdDate { get; set; }

        [Required]
        public DateTime passwordExpirationDate { get; set; }

        [Required]
        public required Boolean isActive { get; set; }

        public ICollection<UserSecurityQuestion> securityQuestions { get; set; } = new List<UserSecurityQuestion>();
    }
}
