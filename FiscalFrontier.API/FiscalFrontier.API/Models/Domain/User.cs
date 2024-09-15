using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiscalFrontier.API.Models.Domain
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } = Guid.NewGuid();

        [Required, StringLength(100)]
        public string UserName { get; set; }
        //Need to set password criteria later. 
        [Required, StringLength(255)]
        public string Password { get; set; }

        [Required,StringLength(255), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime PasswordExpirationDate { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }


        public Role Role { get; set; }
    }
}
