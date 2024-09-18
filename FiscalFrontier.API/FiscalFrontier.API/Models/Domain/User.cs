using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalFrontier.API.Models.Domain
{
    public class User
    {
        [Key]
        public Guid userId { get; set; } = Guid.NewGuid();

        [Required, StringLength(100)]
        public required string username { get; set; }

        //Need to set password criteria later. 
        [Required, StringLength(255)]
        public required string password { get; set; }

        [Required,StringLength(255), EmailAddress]
        public required string email { get; set; }

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

        [ForeignKey("Role")]
        public int roleId { get; set; }

        public Role role { get; set; }

        public ICollection<UserSecurityQuestion> securityQuestions { get; set; } = new List<UserSecurityQuestion>();
    }
}
